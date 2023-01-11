using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Core.Shared.SignalR;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork;
using WRMC.Server.Extensions;
using WRMC.Server.Hubs;

namespace WRMC.Server.Controllers
{
    [Route("api/v1/server/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IHubContext<MainHub, IMainHub> _mainHubContext;

        public UserController(IUnitOfWork unitOfWork,
            IMapper mapper, IHubContext<MainHub, IMainHub> mainHub,
            IPasswordHasher<User> passwordHasher)
        {
            _mapper = mapper;
            _mainHubContext = mainHub;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }


        #region User


        /// <summary>
        /// Add New User by email and with password. return newly added id as string
        /// </summary>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost("New")]
        public async Task<IActionResult> AddNewUser(NewUserRequest request)
        {

            if (await _unitOfWork.Users.AnyAsync(a => a.Email != null && a.Email.Equals(request.Email)))
                return Conflict(await Result<TokenResponse>.FailAsync("Email is is already exist."));
            var user = _mapper.Map<User>(request);
            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            //Add User
            var userEntity = await _unitOfWork.Users.AddAsync(user);

            //Create UserSettings
            await _unitOfWork.UserSettings.AddAsync(new UserSetting
            {
                UserId = userEntity.Entity.Id,
                Culture = "en-US",
                DarkMode = false,
                RightToLeft = false,
            });

            //Create UserProfiles
            await _unitOfWork.UserProfiles.AddAsync(new UserProfile
            {
                UserId = userEntity.Entity.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
            });


            //Assign Default Role
            var clientRole = await _unitOfWork.Roles.GetFirstOrDefaultAsync(predicate: x => x.Name.Equals(AppRoles.Client));
            if (clientRole != null)
            {
                await _unitOfWork.UserRoles.AddAsync(new UserRole(userEntity.Entity.Id, clientRole.Id));
            }

            //TODO : Send Email Verification Code
            await _unitOfWork.SaveChangesAsync();

            return Ok(await Result<string>.SuccessAsync(userEntity.Entity.Id.ToString(), "User successfully created."));

        }


        /// <summary>
        /// Check If Email Exist
        /// </summary>
        /// <param name="email"></param>
        /// <returns>bool</returns>
        [HttpGet("emails")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> CheckIfEmailExist(string email)
        {

            if (string.IsNullOrWhiteSpace(email))
                return BadRequest(await Result.FailAsync("Invalid request."));

            var exist = await _unitOfWork.Users.AnyAsync(x => x.Email.Equals(email));

            return Ok(await Result<bool>.SuccessAsync(exist));

        }

        /// <summary>
        /// Get List Of Users
        /// </summary>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="paged"></param>
        /// <returns>List or PagedList of UserResponse</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IPagedList<UserResponse>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserResponse>))]
        public async Task<IActionResult> GetUsers(string? query = null, int page = 0, int pageSize = 10, bool paged = true)
        {
            if (paged)
            {
                var users = await _unitOfWork.Users.GetPagedListAsync(
                predicate: x => !string.IsNullOrWhiteSpace(query) ? x.Email.ToLower().Contains(query) : true,
                include: i => i.Include(x => x.UserClaims)
                    .Include(x => x.UserSetting)
                    .Include(x => x.UserProfile)
                    .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                    .Include(x => x.UserSessions),
                orderBy: o => o.OrderByDescending(k => k.CreatedDate),
                pageIndex: Convert.ToInt32(page),
                pageSize: Convert.ToInt32(pageSize) > 100 ? 100 : Convert.ToInt32(pageSize));


                var response = _mapper.Map<PagedList<UserResponse>>(users);

                return Ok(await Result<IPagedList<UserResponse>>.SuccessAsync(response));

            }
            else
            {
                var users = await _unitOfWork.Users.GetAllAsync(
            predicate: x => !string.IsNullOrWhiteSpace(query) ? x.Email.ToLower().Contains(query) : true,
            orderBy: o => o.OrderByDescending(k => k.CreatedDate),
            include: i => i.Include(x => x.UserClaims)
                .Include(x => x.UserSetting)
                .Include(x => x.UserProfile)
                .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                .Include(x => x.UserSessions));
                var response = _mapper.Map<List<UserResponse>>(users);
                return Ok(await Result<List<UserResponse>>.SuccessAsync(response));
            }
        }


        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>UserResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        public async Task<IActionResult> GetUserById(string id)
        {
            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(
                predicate: x => x.Id.ToString().Equals(id),
                include: i => i.Include(x => x.UserClaims)
                    .Include(x => x.UserSetting)
                    .Include(x => x.UserProfile).ThenInclude(x=>x.IntroMethod).ThenInclude(x=>x.Parent).ThenInclude(x => x.Parent).ThenInclude(x => x.Parent)
                    .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                    .Include(x => x.UserSessions));

            var response = _mapper.Map<UserResponse>(user);


            return Ok(await Result<UserResponse>.SuccessAsync(response));
        }


        /// <summary>
        /// Update User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateUserById(string id, [FromBody] JsonPatchDocument<UserRequest> request)
        {
            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var requestToPatch = _mapper.Map<UserRequest>(user);
            request.ApplyTo(requestToPatch);
            _mapper.Map(requestToPatch, user);
            _unitOfWork.Users.Update(user);

            await _unitOfWork.SaveChangesAsync();

            //SignalR
            var hubUsers = new List<string>() { user.Id.ToString().ToLower() };
            await _mainHubContext.Clients.Users(hubUsers).UpdateUser(hubUsers);

            return Ok(await Result<bool>.SuccessAsync(true, "User successfully updated."));
        }


        /// <summary>
        /// Change User Password
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPost("{id}/change-password")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> ChangePassword(string id, [FromBody] ChangePasswordRequest request)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.CurrentPassword);

            if (result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.PasswordToken = null;
                user.PasswordTokenExpires = null;
                user.PasswordResetAt = DateTime.UtcNow;
                await _unitOfWork.SaveChangesAsync();

                //SignalR
                var hubUsers = new List<string>() { user.Id.ToString().ToLower() };
                await _mainHubContext.Clients.Users(hubUsers).UpdateUser(hubUsers);
                await _mainHubContext.Clients.Users(hubUsers).RegenerateTokens();

                return Ok(await Result<bool>.SuccessAsync(true, "Password successfully changed."));
            }
            else
                return NotFound(await Result.FailAsync("Incorrect Password."));

        }

        /// <summary>
        /// Delete User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteUserById(string id)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            _unitOfWork.Users.Remove(user);
            await _unitOfWork.SaveChangesAsync();


            return Ok(await Result<bool>.SuccessAsync(true, "User successfully deleted."));

        }

        /// <summary>
        /// Get Profile Completion Status
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of string</returns>
        [HttpGet("{id}/Profile/Status")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<string>))]
        public async Task<IActionResult> GetProfileStatus(string id)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(Guid.Parse(id)),
                include: i => i.Include(x => x.UserProfile));

            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var userRsponse = _mapper.Map<UserResponse>(user);
            var userRequest = _mapper.Map<UserProfileRequest>(userRsponse);

            var errors = new List<string>();
            var properties = userRequest.GetType().GetProperties();
            var validationRequireProps = properties.Where(x => x.GetCustomAttributes(typeof(ValidationAttribute), true).Any()).ToList();


            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool IsValid = Validator.TryValidateObject(userRequest, new ValidationContext(userRequest), validationResults, true);

            if (!IsValid)
            {
                foreach (ValidationResult result in validationResults)
                {
                    errors.Add(result.ErrorMessage);
                }
            }
            //var percent = (int)Math.Round((double)(100 * validationResults.SelectMany(x => x.MemberNames).Distinct().Count()) / validationRequireProps.Count);

            return Ok(await Result<int>.SuccessAsync(validationResults.SelectMany(x => x.MemberNames).Distinct().Count(), errors));

        }

        #endregion

        #region UserSession
        /// <summary>
        /// Get User Sessions
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of UserSessionResponse</returns>
        [HttpGet("{id}/sessions")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserSessionResponse>))]
        public async Task<IActionResult> GetUserSessionsByUserId(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var userSession = await _unitOfWork.UserSessions.GetAllAsync(predicate: x => x.UserId == user.Id);
            var response = _mapper.Map<List<UserSessionResponse>>(userSession);

            return Ok(await Result<List<UserSessionResponse>>.SuccessAsync(response));


        }


        /// <summary>
        /// Terminate Session By SessionId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpDelete("sessions/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> TerminateSession(string id)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var session = await _unitOfWork.UserSessions.FindAsync(Guid.Parse(id));
            if (session is null)
                return NotFound(await Result.FailAsync("Session not found."));

            _unitOfWork.UserSessions.Remove(session);
            await _unitOfWork.SaveChangesAsync();

            //SignalR
            var hubUsers = new List<string>() { session.UserId.ToString().ToLowerInvariant() };
            await _mainHubContext.Clients.Users(hubUsers).TerminateSession(hubUsers);

            return Ok(await Result<bool>.SuccessAsync(true, "Session successfully Terminated."));

        }

        #endregion

        #region UserClaim

        /// <summary>
        /// Get User Claims
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of ClaimResponse</returns>
        [HttpGet("{id}/claims")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClaimResponse>))]
        public async Task<IActionResult> GetUserClaims(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var userClaims = await _unitOfWork.UserClaims.GetAllAsync(predicate: x => x.UserId == user.Id);
            var response = _mapper.Map<List<ClaimResponse>>(userClaims);

            return Ok(await Result<List<ClaimResponse>>.SuccessAsync(response));


        }


        /// <summary>
        /// Update User Claims
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPut("{id}/claims")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateUserClaims(string id, [FromBody] List<ClaimRequest> request)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            _unitOfWork.UserClaims.RemoveRange(predicate: x => x.UserId == user.Id);
            foreach (var item in request)
            {
                if (item is not null)
                    await _unitOfWork.UserClaims.AddAsync(new UserClaim { UserId = Guid.Parse(id), ClaimType = item.ClaimType, ClaimValue = item.ClaimValue });
            }
            await _unitOfWork.SaveChangesAsync();


            //SignalR
            var hubUsers = new List<string>() { id.ToLowerInvariant() };
            await _mainHubContext.Clients.Users(hubUsers).UpdateAuthState(hubUsers);

            return Ok(await Result<bool>.SuccessAsync(true, "User claims successfully updated."));

        }

        #endregion


        #region UserRole

        /// <summary>
        /// Remove Role From User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpDelete("{id}/roles")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> RemoveUserRole(string userId, string roleId)
        {
            if (userId is null)
                return BadRequest(await Result.FailAsync("Invalid user id."));

            if (roleId is null)
                return BadRequest(await Result.FailAsync("Invalid role id."));

            var userRole = await _unitOfWork.UserRoles.GetFirstOrDefaultAsync(
                predicate: x => x.RoleId.ToString().Equals(roleId) && x.UserId.ToString().Equals(userId));

            if (userRole == null)
                return NotFound(await Result.FailAsync("UserRole not found."));

            _unitOfWork.UserRoles.Remove(userRole);
            await _unitOfWork.SaveChangesAsync();


            //SignalR
            var hubUsers = new List<string>() { userId.ToLowerInvariant() };
            await _mainHubContext.Clients.Users(hubUsers).UpdateAuthState(hubUsers);

            return Ok(await Result<bool>.SuccessAsync(true, "UserRole successfully removed."));
        }



        /// <summary>
        /// Assign Role To User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns>UserRoleId as string</returns>
        [HttpPost("{id}/roles")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddUserRole(string userId, string roleId)
        {
            if (userId is null)
                return BadRequest(await Result.FailAsync("Invalid user id."));

            if (roleId is null)
                return BadRequest(await Result.FailAsync("Invalid role id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(roleId));
            if (role is null)
                return NotFound(await Result.FailAsync("Role not found."));

            if (await _unitOfWork.UserRoles.AnyAsync(x => x.UserId == user.Id && x.RoleId == role.Id))
                return Conflict(await Result.FailAsync("Alredy assign."));
            var userRole = new UserRole(Guid.Parse(userId), Guid.Parse(roleId));
            await _unitOfWork.UserRoles.AddAsync(userRole);
            await _unitOfWork.SaveChangesAsync();


            //SignalR
            var hubUsers = new List<string>() { userId.ToLowerInvariant() };
            await _mainHubContext.Clients.Users(hubUsers).UpdateAuthState(hubUsers);

            return Ok(await Result<bool>.SuccessAsync(true, "Role successfully assigned to user."));
        }



        /// <summary>
        /// Get User Roles
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of RoleResponse</returns>
        [HttpGet("{id}/roles")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserRoleResponse>))]
        public async Task<IActionResult> GetUserRoles(string id)
        {
            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var userRoles = await _unitOfWork.UserRoles.GetAllAsync(predicate: x => x.UserId == user.Id,
                include: i => i.Include(x => x.Role));
            var response = _mapper.Map<List<UserRoleResponse>>(userRoles);

            return Ok(await Result<List<UserRoleResponse>>.SuccessAsync(response));
        }



        /// <summary>
        /// Update UserRoles 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request">list of roles to replaced</param>
        /// <returns>bool</returns>
        [HttpPut("{id}/roles")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateUserRoles(string id, [FromBody] List<string> request)
        {
            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(id), disableTracking: true);
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));
            _unitOfWork.UserRoles.RemoveRange(predicate: x => x.UserId == user.Id);


            //await _unitOfWork.SaveChangesAsync();

            foreach (var item in request)
            {
                if (item is not null)
                    await _unitOfWork.UserRoles.AddAsync(new UserRole { UserId = user.Id, RoleId = Guid.Parse(item) });
            }
            await _unitOfWork.SaveChangesAsync();

            //SignalR
            var hubUsers = new List<string>() { id.ToLowerInvariant() };
            await _mainHubContext.Clients.Users(hubUsers).UpdateAuthState(hubUsers);

            return Ok(await Result<bool>.SuccessAsync(true, "User roles successfully updated."));
        }

        #endregion

        #region UserSettings


        /// <summary>
        /// Add User Settings
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost("{id}/settings")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddUserSetting(string id, UserSettingRequest request)
        {
            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var setting = _mapper.Map<UserSetting>(request);
            setting.UserId = user.Id;
            var entity = await _unitOfWork.UserSettings.AddAsync(setting);
            await _unitOfWork.SaveChangesAsync();

            //SignalR
            var hubUsers = new List<string>() { id.ToLowerInvariant() };
            await _mainHubContext.Clients.Users(hubUsers).UpdateUser(hubUsers);


            return Ok(await Result<string>.SuccessAsync(entity.Entity.Id.ToString(), "Setting successfully created."));

        }


        /// <summary>
        /// Get User Settings
        /// </summary>
        /// <param name="id"></param>
        /// <returns>UserSettingResponse</returns>
        [HttpGet("{id}/settings")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserSettingResponse))]
        public async Task<IActionResult> GetUserSetting(string id)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var userSetting = await _unitOfWork.UserSettings.GetFirstOrDefaultAsync(
                predicate: x => x.Id.ToString().Equals(id));

            if (userSetting is null)
                return NotFound(await Result.FailAsync("Setting not found."));

            var response = _mapper.Map<UserSettingResponse>(userSetting);

            return Ok(await Result<UserSettingResponse>.SuccessAsync(response));

        }


        /// <summary>
        /// Update User Settings
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{id}/settings")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateUserSetting(string id, [FromBody] JsonPatchDocument<UserSettingRequest> request)
        {
            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var setting = await _unitOfWork.UserSettings.GetFirstOrDefaultAsync(predicate: x => x.UserId.Equals(user.Id));
            if (setting is null)
                return NotFound(await Result.FailAsync("User Setting not found."));

            var requestToPatch = _mapper.Map<UserSettingRequest>(setting);
            request.ApplyTo(requestToPatch);
            _mapper.Map(requestToPatch, setting);
            _unitOfWork.UserSettings.Update(setting);
            await _unitOfWork.SaveChangesAsync();

            //SignalR
            var hubUsers = new List<string>() { id.ToLowerInvariant() };
            await _mainHubContext.Clients.Users(hubUsers).UpdateUser(hubUsers);

            return Ok(await Result<bool>.SuccessAsync(true, "Setting successfully updated."));
        }


        /// <summary>
        /// Delete User Settings
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpDelete("{id}/settings")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteUserSetting(string id)
        {
            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));


            var setting = await _unitOfWork.UserSettings.GetFirstOrDefaultAsync(predicate: x => x.UserId.Equals(user.Id));
            if (setting is null)
                return NotFound(await Result.FailAsync("Setting not found."));

            _unitOfWork.UserSettings.Remove(setting);
            await _unitOfWork.SaveChangesAsync();

            //SignalR
            var hubUsers = new List<string>() { id.ToLowerInvariant() };
            await _mainHubContext.Clients.Users(hubUsers).UpdateUser(hubUsers);

            return Ok(await Result<bool>.SuccessAsync(true, "Setting successfully deleted."));

        }

        #endregion

        #region UserProfile

        /// <summary>
        /// Add UserProfile
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost("{id}/user-profile")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddUserProfile(string id, UserProfileRequest request)
        {
            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var profile = _mapper.Map<UserProfile>(request);
            profile.UserId = user.Id;
            var entity = await _unitOfWork.UserProfiles.AddAsync(profile);
            await _unitOfWork.SaveChangesAsync();

            //SignalR
            var hubUsers = new List<string>() { id.ToLowerInvariant() };
            await _mainHubContext.Clients.Users(hubUsers).UpdateUser(hubUsers);

            return Ok(await Result<string>.SuccessAsync(entity.Entity.Id.ToString(), "Profile successfully created."));
        }


        /// <summary>
        /// Get UserProfile
        /// </summary>
        /// <param name="id"></param>
        /// <returns>UserProfileResponse</returns>
        [HttpGet("{id}/user-profile")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserProfileResponse))]
        public async Task<IActionResult> GetUserProfile(string id)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var userProfile = await _unitOfWork.UserProfiles.GetFirstOrDefaultAsync(
                predicate: x => x.Id.ToString().Equals(id),
                include: i =>i.Include(x => x.IntroMethod).ThenInclude(x => x.Parent).ThenInclude(x => x.Parent).ThenInclude(x => x.Parent));

            var response = _mapper.Map<UserProfileResponse>(userProfile);

            return Ok(await Result<UserProfileResponse>.SuccessAsync(response));
        }

        /// <summary>
        /// Update UserProfile
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{id}/user-profile")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateUserProfile(string id, [FromBody] JsonPatchDocument<UserProfileRequest> request)
        {
            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var userProfile = await _unitOfWork.UserProfiles.GetFirstOrDefaultAsync(predicate: x => x.UserId.Equals(user.Id));
            if (userProfile is null)
                return NotFound(await Result.FailAsync("Profile not found."));

            var userProfileRequest = _mapper.Map<UserProfileRequest>(userProfile);
            request.ApplyTo(userProfileRequest);
            _mapper.Map(userProfileRequest, userProfile);

            _unitOfWork.UserProfiles.Update(userProfile);
            await _unitOfWork.SaveChangesAsync();


            //SignalR
            var hubUsers = new List<string>() { id.ToLowerInvariant() };
            await _mainHubContext.Clients.Users(hubUsers).UpdateUser(hubUsers);

            return Ok(await Result<bool>.SuccessAsync(true, "Profile successfully updated."));
        }


        /// <summary>
        /// Delete UserProfile
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpDelete("{id}/user-profile")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));


            var userProfile = await _unitOfWork.UserProfiles.GetFirstOrDefaultAsync(predicate: x => x.UserId.Equals(user.Id));
            if (userProfile is null)
                return NotFound(await Result.FailAsync("Profile not found."));

            _unitOfWork.UserProfiles.Remove(userProfile);
            await _unitOfWork.SaveChangesAsync();

            //SignalR
            var hubUsers = new List<string>() { id.ToLowerInvariant() };
            await _mainHubContext.Clients.Users(hubUsers).UpdateUser(hubUsers);


            return Ok(await Result<bool>.SuccessAsync(true, "Profile successfully deleted."));
        }


        #endregion

        #region UserPhoneNumbers

        /// <summary>
        /// Add UserPhoneNumber
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost("{id}/phone-numbers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddPhoneNumber(string id, UserPhoneNumberRequest request)
        {
            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var phoneNumber = _mapper.Map<UserPhoneNumber>(request);
            phoneNumber.UserId = user.Id;
            var entity = await _unitOfWork.UserPhoneNumbers.AddAsync(phoneNumber);
            await _unitOfWork.SaveChangesAsync();

            return Ok(await Result<string>.SuccessAsync(entity.Entity.Id.ToString(), "PhoneNumber successfully Added."));
        }


        /// <summary>
        /// Get UserPhoneNumbers
        /// </summary>
        /// <param name="id"></param>
        /// <returns>UserPhoneNumberResponse</returns>
        [HttpGet("{id}/phone-numbers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserPhoneNumberResponse>))]
        public async Task<IActionResult> GetPhoneNumbers(string id)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var phoneNumbers = await _unitOfWork.UserPhoneNumbers.GetAllAsync(
                predicate: x => x.UserId.ToString().Equals(id),
                orderBy: o => o.OrderBy(x => x.Order));


            var response = _mapper.Map<List<UserPhoneNumberResponse>>(phoneNumbers);

            return Ok(await Result<List<UserPhoneNumberResponse>>.SuccessAsync(response));

        }


        /// <summary>
        /// Get UserPhoneNumber
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pid"></param>
        /// <returns>UserPhoneNumberResponse</returns>
        [HttpGet("{id}/phone-numbers/{pid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserPhoneNumberResponse))]
        public async Task<IActionResult> GetPhoneNumber(string id, string pid)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var phoneNumber = await _unitOfWork.UserPhoneNumbers.GetFirstOrDefaultAsync(
                predicate: x => x.UserId.ToString().Equals(id) && x.Id.ToString().Equals(pid));

            var response = _mapper.Map<UserPhoneNumberResponse>(phoneNumber);

            return Ok(await Result<UserPhoneNumberResponse>.SuccessAsync(response));

        }


        /// <summary>
        /// Update UserPhoneNumber
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pid"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{id}/phone-numbers/{pid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateUserPhoneNumbers(string id, string pid, [FromBody] JsonPatchDocument<UserPhoneNumberRequest> request)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var userPhoneNumber = await _unitOfWork.UserPhoneNumbers.GetFirstOrDefaultAsync(predicate: x => x.UserId.Equals(user.Id) && x.Id.ToString().Equals(pid));
            if (userPhoneNumber is null)
                return NotFound(await Result.FailAsync("PhoneNumber not found."));

            var requestToPatch = _mapper.Map<UserPhoneNumberRequest>(userPhoneNumber);
            request.ApplyTo(requestToPatch);
            _mapper.Map(requestToPatch, userPhoneNumber);
            _unitOfWork.UserPhoneNumbers.Update(userPhoneNumber);
            await _unitOfWork.SaveChangesAsync();
            return Ok(await Result<bool>.SuccessAsync(true, "PhoneNumber successfully updated."));

        }



        /// <summary>
        /// Delete PhoneNumber
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pid"></param>
        /// <returns>bool</returns>
        [HttpDelete("{id}/phone-numbers/{pid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeletePhoneNumber(string id, string pid)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));


            var phoneNumber = await _unitOfWork.UserPhoneNumbers.GetFirstOrDefaultAsync(
                predicate: x => x.UserId.ToString().Equals(id) && x.Id.ToString().Equals(pid));

            if (phoneNumber is null)
                return NotFound(await Result.FailAsync("PhoneNumber not found."));

            _unitOfWork.UserPhoneNumbers.Remove(phoneNumber);
            await _unitOfWork.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, "PhoneNumber successfully deleted."));

        }


        #endregion

        #region UserAddress

        /// <summary>
        /// Add UserAddress
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost("{id}/addresses")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddAddress(string id, UserAddressRequest request)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var address = _mapper.Map<UserAddress>(request);
            address.UserId = user.Id;
            var entity = await _unitOfWork.UserAddresses.AddAsync(address);
            await _unitOfWork.SaveChangesAsync();
            return Ok(await Result<string>.SuccessAsync(entity.Entity.Id.ToString(), "Address successfully Added."));

        }


        /// <summary>
        /// Get UserAddresses
        /// </summary>
        /// <param name="id"></param>
        /// <returns>list of UserAddressResponse</returns>
        [HttpGet("{id}/addresses")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserAddressResponse>))]
        public async Task<IActionResult> GetAddresses(string id)
        {


            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid Request id."));

            var addresses = await _unitOfWork.UserAddresses.GetAllAsync(
                predicate: x => x.UserId.ToString().Equals(id),
                include: i => i.Include(x => x.Region).ThenInclude(x => x.Parent).ThenInclude(x => x.Parent),
                orderBy: o => o.OrderBy(x => x.Order));


            var response = _mapper.Map<List<UserAddressResponse>>(addresses);

            return Ok(await Result<List<UserAddressResponse>>.SuccessAsync(response));

        }



        /// <summary>
        /// Get UserAddress
        /// </summary>
        /// <param name="id">UserId</param>
        /// <param name="aid">Address Id</param>
        /// <returns>UserAddressResponse</returns>
        [HttpGet("{id}/addresses/{aid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserAddressResponse))]
        public async Task<IActionResult> GetAddress(string id, string aid)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var phoneNumber = await _unitOfWork.UserAddresses.GetFirstOrDefaultAsync(
                predicate: x => x.UserId.ToString().Equals(id) && x.Id.ToString().Equals(aid),
                include: i => i.Include(x => x.Region).ThenInclude(x => x.Parent).ThenInclude(x => x.Parent));

            if (phoneNumber is null)
                return NotFound(await Result.FailAsync("Address not found."));


            var response = _mapper.Map<UserAddressResponse>(phoneNumber);

            return Ok(await Result<UserAddressResponse>.SuccessAsync(response));

        }


        /// <summary>
        /// Update UserAddress
        /// </summary>
        /// <param name="id">UserId</param>
        /// <param name="aid">Address Id</param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{id}/addresses/{aid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateUserAddress(string id, string aid, [FromBody] JsonPatchDocument<UserAddressRequest> request)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var userAddress = await _unitOfWork.UserAddresses.GetFirstOrDefaultAsync(predicate: x => x.UserId.Equals(user.Id) && x.Id.ToString().Equals(aid));
            if (userAddress is null)
                return NotFound(await Result.FailAsync("UserAddress not found."));

            var requestToPatch = _mapper.Map<UserAddressRequest>(userAddress);
            request.ApplyTo(requestToPatch);
            _mapper.Map(requestToPatch, userAddress);
            _unitOfWork.UserAddresses.Update(userAddress);
            await _unitOfWork.SaveChangesAsync();
            return Ok(await Result<bool>.SuccessAsync(true, "UserAddress successfully updated."));

        }



        /// <summary>
        /// Delete UserAddress
        /// </summary>
        /// <param name="id">UserId</param>
        /// <param name="aid">AddressId</param>
        /// <returns>bool</returns>
        [HttpDelete("{id}/addresses/{aid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteAddress(string id, string aid)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));


            var address = await _unitOfWork.UserAddresses.GetFirstOrDefaultAsync(
                predicate: x => x.UserId.ToString().Equals(id) && x.Id.ToString().Equals(aid));

            if (address is null)
                return NotFound(await Result.FailAsync("Address not found."));

            _unitOfWork.UserAddresses.Remove(address);
            await _unitOfWork.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, "Address successfully deleted."));

        }


        #endregion

        #region UserAttachment

        /// <summary>
        /// Add UserAttachment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost("{id}/attachments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddAttachment(string id, UserAttachmentRequest request)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));

            var address = _mapper.Map<UserAttachment>(request);
            address.UserId = user.Id;
            var entity = await _unitOfWork.UserAttachments.AddAsync(address);
            await _unitOfWork.SaveChangesAsync();
            return Ok(await Result<string>.SuccessAsync(entity.Entity.Id.ToString(), "Attachment successfully Added."));

        }


        /// <summary>
        /// Get UserAttachments
        /// </summary>
        /// <param name="id"></param>
        /// <returns>list of UserAttachmentResponse</returns>
        [HttpGet("{id}/attachments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserAttachmentResponse>))]
        public async Task<IActionResult> GetAttachments(string id)
        {


            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var attachments = await _unitOfWork.UserAttachments.GetAllAsync(
                predicate: x => x.UserId.ToString().Equals(id),
                orderBy: o => o.OrderBy(x => x.Order));


            var response = _mapper.Map<List<UserAttachmentResponse>>(attachments);

            return Ok(await Result<List<UserAttachmentResponse>>.SuccessAsync(response));

        }



        /// <summary>
        /// Get UserAttachment
        /// </summary>
        /// <param name="id">UserId</param>
        /// <param name="aid">AttachmentId</param>
        /// <returns>UserAttachmentResponse</returns>
        [HttpGet("{id}/attachments/{aid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserAttachmentResponse))]
        public async Task<IActionResult> GetAttachment(string id, string aid)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var attachment = await _unitOfWork.UserAttachments.GetFirstOrDefaultAsync(
                predicate: x => x.UserId.ToString().Equals(id) && x.Id.ToString().Equals(aid));

            if (attachment is null)
                return NotFound(await Result.FailAsync("Attachment not found."));


            var response = _mapper.Map<UserAttachmentResponse>(attachment);

            return Ok(await Result<UserAttachmentResponse>.SuccessAsync(response));

        }


        /// <summary>
        /// Delete UserAttachment
        /// </summary>
        /// <param name="id">UserId</param>
        /// <param name="aid">AttachmentId</param>
        /// <returns>bool</returns>
        [HttpDelete("{id}/attachments/{aid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteAttachment(string id, string aid)
        {

            if (id is null)
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(id));
            if (user is null)
                return NotFound(await Result.FailAsync("User not found."));


            var attachment = await _unitOfWork.UserAttachments.GetFirstOrDefaultAsync(
                predicate: x => x.UserId.ToString().Equals(id) && x.Id.ToString().Equals(aid));

            if (attachment is null)
                return NotFound(await Result.FailAsync("Attachment not found."));

            _unitOfWork.UserAttachments.Remove(attachment);
            await _unitOfWork.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, "Attachment successfully deleted."));

        }


        #endregion

    }
}
