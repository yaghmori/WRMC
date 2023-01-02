using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WRMC.Core.Shared.Constant;
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
        private readonly IUnitOfWork<ServerDbContext> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IHubContext<MainHub,IMainHub> _mainHubContext;

        public UserController(IUnitOfWork<ServerDbContext> unitOfWork,
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
        /// Add New User by email and with password. return newly added userId as string
        /// </summary>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost("New")]
        public async Task<IActionResult> AddNewUser(NewUserRequest request)
        {

            try
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
                var clientRole = await _unitOfWork.Roles.GetFirstOrDefaultAsync(predicate: x => x.Name.Equals(ApplicationRoles.Client));
                if (clientRole != null)
                {
                    await _unitOfWork.UserRoles.AddAsync(new UserRole(userEntity.Entity.Id, clientRole.Id));
                }

                //TODO : Send Email Verification Code
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<string>.SuccessAsync(userEntity.Entity.Id.ToString(), "User successfully created."));


            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }

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
            try
            {
                if (paged)
                {
                    var users = await _unitOfWork.Users.GetPagedListAsync(
                    predicate: x => !string.IsNullOrWhiteSpace(query) ? x.Email.ToLower().Contains(query) : true,
                    include: i => i.Include(x => x.UserClaims)
                        .Include(x => x.UserSetting)
                        .Include(x => x.UserProfile).ThenInclude(x => x.IntroMethod)
                        .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                        .Include(x => x.UserTenants).ThenInclude(x => x.Tenant)
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
                    .Include(x => x.UserProfile).ThenInclude(x => x.IntroMethod)
                    .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                    .Include(x => x.UserTenants).ThenInclude(x => x.Tenant)
                    .Include(x => x.UserSessions));
                    var response = _mapper.Map<List<UserResponse>>(users);
                    return Ok(await Result<List<UserResponse>>.SuccessAsync(response));
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>UserResponse</returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {

                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(
                    predicate: x => x.Id.ToString().Equals(userId),
                    include: i => i.Include(x => x.UserClaims)
                        .Include(x => x.UserSetting)
                        .Include(x => x.UserProfile).ThenInclude(x => x.IntroMethod)
                        .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                        .Include(x => x.UserTenants).ThenInclude(x => x.Tenant)
                        .Include(x => x.UserSessions));

                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                var response = _mapper.Map<UserResponse>(user);

                return Ok(await Result<UserResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Update User By Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateUserById(string userId, [FromBody] JsonPatchDocument<UserRequest> request)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                var requestToPatch = _mapper.Map<UserRequest>(user);
                request.ApplyTo(requestToPatch);
                _mapper.Map(requestToPatch, user);
                _unitOfWork.Users.Update(user);

                await _unitOfWork.SaveChangesAsync();

                //SignalR
                //await _mainHubContext.UpdateUser(new List<string>() { user.Id.ToString() });

                return Ok(await Result<bool>.SuccessAsync(true, "User successfully updated."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Change User Password
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPost("{userId}/change-password")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> ChangePassword(string userId, [FromBody] ChangePasswordRequest request)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.CurrentPassword);

                if (result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded)
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, request.NewPassword);
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    user.PasswordToken = null;
                    user.PasswordTokenExpires = null;
                    user.PasswordResetAt = DateTime.UtcNow;
                    await _unitOfWork.SaveChangesAsync();

                    return Ok(await Result<bool>.SuccessAsync(true, "Password successfully changed."));
                }
                else
                    return NotFound(await Result.FailAsync("Incorrect Password."));

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Delete User By Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>bool</returns>
        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteUserById(string userId)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                _unitOfWork.Users.Remove(user);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "User successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Get Profile Completion Status
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of string</returns>
        [HttpGet("{userId}/Profile/Status")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<string>))]
        public async Task<IActionResult> GetProfileStatus(string userId)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(Guid.Parse(userId)),
                    include: i => i.Include(x => x.UserProfile).ThenInclude(x => x.IntroMethod));

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
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        #endregion

        #region UserSession
        /// <summary>
        /// Get User Sessions
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of UserSessionResponse</returns>
        [HttpGet("{userId}/sessions")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserSessionResponse>))]
        public async Task<IActionResult> GetUserSessionsByUserId(string userId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId))
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                var userSession = await _unitOfWork.UserSessions.GetAllAsync(predicate: x => x.UserId == user.Id);
                var response = _mapper.Map<List<UserSessionResponse>>(userSession);

                return Ok(await Result<List<UserSessionResponse>>.SuccessAsync(response));

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Terminate Session By SessionId
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns>bool</returns>
        [HttpDelete("sessions/{sessionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> TerminateSession(string sessionId)
        {
            try
            {
                if (sessionId is null)
                    return BadRequest(await Result.FailAsync("SessionId is null or empty."));

                var session = await _unitOfWork.UserSessions.FindAsync(Guid.Parse(sessionId));
                if (session is null)
                    return NotFound(await Result.FailAsync("Session not found."));

                _unitOfWork.UserSessions.Remove(session);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "Session successfully Terminated."));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        #endregion

        #region UserClaim

        /// <summary>
        /// Get User Claims
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of UserClaimResponse</returns>
        [HttpGet("{userId}/claims")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserClaimResponse>))]
        public async Task<IActionResult> GetClaimsByUserId(string userId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId))
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                var userClaims = await _unitOfWork.UserClaims.GetAllAsync(predicate: x => x.UserId == user.Id);
                var response = _mapper.Map<List<UserClaimResponse>>(userClaims);

                return Ok(await Result<List<UserClaimResponse>>.SuccessAsync(response));

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Update User Claims
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPut("{userId}/Claims")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateUserClaims(string userId, [FromBody] List<UserClaimRequest> request)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                _unitOfWork.UserClaims.RemoveRange(predicate: x => x.UserId == user.Id);
                foreach (var item in request)
                {
                    if (item is not null)
                        await _unitOfWork.UserClaims.AddAsync(new UserClaim { UserId = Guid.Parse(userId), ClaimType = item.ClaimType, ClaimValue = item.ClaimValue });
                }
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "User claims successfully updated."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        #endregion

        #region UserTenants
        /// <summary>
        /// Get User Tenants
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of UserTenantResponse</returns>
        [HttpGet("{userId}/tenants")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserTenantResponse>))]
        public async Task<IActionResult> GetUserTenants(string userId)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                var tenants = await _unitOfWork.UserTenants.GetAllAsync(predicate: x => x.UserId == user.Id,
                    include: i => i.Include(x => x.Tenant));
                var response = _mapper.Map<List<UserTenantResponse>>(tenants);

                return Ok(await Result<List<UserTenantResponse>>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }



        /// <summary>
        /// Update User Tenants
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPut("{userId}/Tenants")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateUserTenants(string userId, [FromBody] List<string> request)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                _unitOfWork.UserTenants.RemoveRange(predicate: x => x.UserId == user.Id);
                foreach (var item in request)
                {
                    if (item is not null)
                        await _unitOfWork.UserTenants.AddAsync(new UserTenant { UserId = Guid.Parse(userId), TenantId = Guid.Parse(item) });
                }
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "User tenants successfully updated."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        #endregion

        #region UserRole

        /// <summary>
        /// Remove Role From User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpDelete("{userId}/roles")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> RemoveUserRole(string userId, string roleId)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                if (roleId is null)
                    return BadRequest(await Result.FailAsync("RoleId is null or empty."));

                var userRole = await _unitOfWork.UserRoles.GetFirstOrDefaultAsync(
                    predicate: x => x.RoleId.ToString().Equals(roleId) && x.UserId.ToString().Equals(userId));

                if (userRole == null)
                    return NotFound(await Result.FailAsync("UserRole not found."));

                _unitOfWork.UserRoles.Remove(userRole);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "UserRole successfully removed."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }



        /// <summary>
        /// Assign Role To User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns>UserRoleId as string</returns>
        [HttpPost("{userId}/roles")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddUserRole(string userId, string roleId)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                if (roleId is null)
                    return BadRequest(await Result.FailAsync("RoleId is null or empty."));

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
                return Ok(await Result<bool>.SuccessAsync(true, "Role successfully assigned to user."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }



        /// <summary>
        /// Get User Roles
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of RoleResponse</returns>
        [HttpGet("{userId}/Roles")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserRoleResponse>))]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                var userRoles = await _unitOfWork.UserRoles.GetAllAsync(predicate: x => x.UserId == user.Id,
                    include: i => i.Include(x => x.Role));
                var response = _mapper.Map<List<UserRoleResponse>>(userRoles);

                return Ok(await Result<List<UserRoleResponse>>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }



        /// <summary>
        /// Update UserRoles 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request">list of roles to replaced</param>
        /// <returns>bool</returns>
        [HttpPut("{userId}/Roles")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateUserRoles(string userId, [FromBody] List<string> request)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(userId),
                    disableTracking: true);
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));
                _unitOfWork.UserRoles.RemoveRange(predicate: x => x.UserId == user.Id);


                //await _unitOfWork.SaveChangesAsync();

                foreach (var item in request)
                {
                    if (item is not null)
                        await _unitOfWork.DbContext.UserRoles.AddAsync(new UserRole { UserId = user.Id, RoleId = Guid.Parse(item) });
                }
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "User roles successfully updated."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        #endregion

        #region UserSettings


        /// <summary>
        /// Add User Settings
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost("{userId}/Settings")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddUserSetting(string userId, UserSettingRequest request)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                var setting = _mapper.Map<UserSetting>(request);
                setting.UserId = user.Id;
                var entity = await _unitOfWork.UserSettings.AddAsync(setting);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<string>.SuccessAsync(entity.Entity.Id.ToString(), "Setting successfully created."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get User Settings
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>UserSettingResponse</returns>
        [HttpGet("{userId}/Settings")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserSettingResponse))]
        public async Task<IActionResult> GetUserSetting(string userId)
        {
            try
            {

                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var userSetting = await _unitOfWork.UserSettings.GetFirstOrDefaultAsync(
                    predicate: x => x.Id.ToString().Equals(userId));

                if (userSetting is null)
                    return NotFound(await Result.FailAsync("Setting not found."));

                var response = _mapper.Map<UserSettingResponse>(userSetting);

                return Ok(await Result<UserSettingResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Update User Settings
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{userId}/Settings")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateUserSetting(string userId, [FromBody] JsonPatchDocument<UserSettingRequest> request)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
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
                var users = new List<string>() { user.Id.ToString() };
                await _mainHubContext.Clients.Users(users).UpdateCulture(users);

                return Ok(await Result<bool>.SuccessAsync(true, "Setting successfully updated."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Delete User Settings
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>bool</returns>
        [HttpDelete("{userId}/Settings")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteUserSetting(string userId)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));


                var setting = await _unitOfWork.UserSettings.GetFirstOrDefaultAsync(predicate: x => x.UserId.Equals(user.Id));
                if (setting is null)
                    return NotFound(await Result.FailAsync("Setting not found."));

                _unitOfWork.UserSettings.Remove(setting);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<bool>.SuccessAsync(true, "Setting successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        #endregion

        #region UserProfile

        /// <summary>
        /// Add UserProfile
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost("{userId}/UserProfile")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddUserProfile(string userId, UserProfileRequest request)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                var profile = _mapper.Map<UserProfile>(request);
                profile.UserId = user.Id;
                var entity = await _unitOfWork.UserProfiles.AddAsync(profile);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<string>.SuccessAsync(entity.Entity.Id.ToString(), "Profile successfully created."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get UserProfile
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>UserProfileResponse</returns>
        [HttpGet("{userId}/UserProfile")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserProfileResponse))]
        public async Task<IActionResult> GetUserProfile(string userId)
        {
            try
            {

                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var userProfile = await _unitOfWork.UserProfiles.GetFirstOrDefaultAsync(
                    predicate: x => x.Id.ToString().Equals(userId),
                    include: i => i.Include(x => x.IntroMethod).ThenInclude(x => x.Parent).ThenInclude(x => x.Parent).ThenInclude(x => x.Parent));

                if (userProfile is null)
                    return NotFound(await Result.FailAsync("Personal info not found."));

                var response = _mapper.Map<UserProfileResponse>(userProfile);

                return Ok(await Result<UserProfileResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Update UserProfile
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{userId}/UserProfile")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateUserProfile(string userId, [FromBody] JsonPatchDocument<UserProfileRequest> request)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
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
                return Ok(await Result<bool>.SuccessAsync(true, "Profile successfully updated."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Delete UserProfile
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>bool</returns>
        [HttpDelete("{userId}/UserProfile")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteUserProfile(string userId)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));


                var userProfile = await _unitOfWork.UserProfiles.GetFirstOrDefaultAsync(predicate: x => x.UserId.Equals(user.Id));
                if (userProfile is null)
                    return NotFound(await Result.FailAsync("Profile not found."));

                _unitOfWork.UserProfiles.Remove(userProfile);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<bool>.SuccessAsync(true, "Profile successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        #endregion

        #region UserPhoneNumbers

        /// <summary>
        /// Add UserPhoneNumber
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost("{userId}/PhoneNumbers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddPhoneNumber(string userId, UserPhoneNumberRequest request)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                var phoneNumber = _mapper.Map<UserPhoneNumber>(request);
                phoneNumber.UserId = user.Id;
                var entity = await _unitOfWork.UserPhoneNumbers.AddAsync(phoneNumber);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<string>.SuccessAsync(entity.Entity.Id.ToString(), "PhoneNumber successfully Added."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get UserPhoneNumbers
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>UserPhoneNumberResponse</returns>
        [HttpGet("{userId}/PhoneNumbers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserPhoneNumberResponse>))]
        public async Task<IActionResult> GetPhoneNumbers(string userId)
        {
            try
            {

                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var phoneNumbers = await _unitOfWork.UserPhoneNumbers.GetAllAsync(
                    predicate: x => x.UserId.ToString().Equals(userId),
                    orderBy: o => o.OrderBy(x => x.Order));


                var response = _mapper.Map<List<UserPhoneNumberResponse>>(phoneNumbers);

                return Ok(await Result<List<UserPhoneNumberResponse>>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get UserPhoneNumber
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="phoneNumberId"></param>
        /// <returns>UserPhoneNumberResponse</returns>
        [HttpGet("{userId}/PhoneNumbers/{phoneNumberId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserPhoneNumberResponse))]
        public async Task<IActionResult> GetPhoneNumber(string userId, string phoneNumberId)
        {
            try
            {

                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var phoneNumber = await _unitOfWork.UserPhoneNumbers.GetFirstOrDefaultAsync(
                    predicate: x => x.UserId.ToString().Equals(userId) && x.Id.ToString().Equals(phoneNumberId));

                if (phoneNumber is null)
                    return NotFound(await Result.FailAsync("PhoneNumber not found."));


                var response = _mapper.Map<UserPhoneNumberResponse>(phoneNumber);

                return Ok(await Result<UserPhoneNumberResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Update UserPhoneNumber
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="phoneNumberId"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{userId}/PhoneNumbers/{phoneNumberId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateUserPhoneNumbers(string userId, string phoneNumberId, [FromBody] JsonPatchDocument<UserPhoneNumberRequest> request)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                var userPhoneNumber = await _unitOfWork.UserPhoneNumbers.GetFirstOrDefaultAsync(predicate: x => x.UserId.Equals(user.Id) && x.Id.ToString().Equals(phoneNumberId));
                if (userPhoneNumber is null)
                    return NotFound(await Result.FailAsync("PhoneNumber not found."));

                var requestToPatch = _mapper.Map<UserPhoneNumberRequest>(userPhoneNumber);
                request.ApplyTo(requestToPatch);
                _mapper.Map(requestToPatch, userPhoneNumber);
                _unitOfWork.UserPhoneNumbers.Update(userPhoneNumber);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "PhoneNumber successfully updated."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }



        /// <summary>
        /// Delete PhoneNumber
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="phoneNumberId"></param>
        /// <returns>bool</returns>
        [HttpDelete("{userId}/PhoneNumbers/{phoneNumberId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeletePhoneNumber(string userId, string phoneNumberId)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));


                var phoneNumber = await _unitOfWork.UserPhoneNumbers.GetFirstOrDefaultAsync(
                    predicate: x => x.UserId.ToString().Equals(userId) && x.Id.ToString().Equals(phoneNumberId));

                if (phoneNumber is null)
                    return NotFound(await Result.FailAsync("PhoneNumber not found."));

                _unitOfWork.UserPhoneNumbers.Remove(phoneNumber);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<bool>.SuccessAsync(true, "PhoneNumber successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        #endregion

        #region UserAddress

        /// <summary>
        /// Add UserAddress
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost("{userId}/Addresses")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddAddress(string userId, UserAddressRequest request)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                var address = _mapper.Map<UserAddress>(request);
                address.UserId = user.Id;
                var entity = await _unitOfWork.UserAddresses.AddAsync(address);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<string>.SuccessAsync(entity.Entity.Id.ToString(), "Address successfully Added."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get UserAddresses
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>list of UserAddressResponse</returns>
        [HttpGet("{userId}/Addresses")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserAddressResponse>))]
        public async Task<IActionResult> GetAddresses(string userId)
        {
            try
            {

                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var addresses = await _unitOfWork.UserAddresses.GetAllAsync(
                    predicate: x => x.UserId.ToString().Equals(userId),
                    include: i => i.Include(x => x.Region).ThenInclude(x => x.Parent).ThenInclude(x => x.Parent),
                    orderBy: o => o.OrderBy(x => x.Order));


                var response = _mapper.Map<List<UserAddressResponse>>(addresses);

                return Ok(await Result<List<UserAddressResponse>>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }



        /// <summary>
        /// Get UserAddress
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="addressId"></param>
        /// <returns>UserAddressResponse</returns>
        [HttpGet("{userId}/Addresses/{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserAddressResponse))]
        public async Task<IActionResult> GetAddress(string userId, string addressId)
        {
            try
            {

                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var phoneNumber = await _unitOfWork.UserAddresses.GetFirstOrDefaultAsync(
                    predicate: x => x.UserId.ToString().Equals(userId) && x.Id.ToString().Equals(addressId),
                    include: i => i.Include(x => x.Region).ThenInclude(x => x.Parent).ThenInclude(x => x.Parent));

                if (phoneNumber is null)
                    return NotFound(await Result.FailAsync("Address not found."));


                var response = _mapper.Map<UserAddressResponse>(phoneNumber);

                return Ok(await Result<UserAddressResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Update UserAddress
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="addressId"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{userId}/Addresses/{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateUserAddress(string userId, string addressId, [FromBody] JsonPatchDocument<UserAddressRequest> request)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                var userAddress = await _unitOfWork.UserAddresses.GetFirstOrDefaultAsync(predicate: x => x.UserId.Equals(user.Id) && x.Id.ToString().Equals(addressId));
                if (userAddress is null)
                    return NotFound(await Result.FailAsync("UserAddress not found."));

                var requestToPatch = _mapper.Map<UserAddressRequest>(userAddress);
                request.ApplyTo(requestToPatch);
                _mapper.Map(requestToPatch, userAddress);
                _unitOfWork.UserAddresses.Update(userAddress);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "UserAddress successfully updated."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }



        /// <summary>
        /// Delete UserAddress
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="addressId"></param>
        /// <returns>bool</returns>
        [HttpDelete("{userId}/Addresses/{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteAddress(string userId, string addressId)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));


                var address = await _unitOfWork.UserAddresses.GetFirstOrDefaultAsync(
                    predicate: x => x.UserId.ToString().Equals(userId) && x.Id.ToString().Equals(addressId));

                if (address is null)
                    return NotFound(await Result.FailAsync("Address not found."));

                _unitOfWork.UserAddresses.Remove(address);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<bool>.SuccessAsync(true, "Address successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        #endregion

        #region UserAttachment

        /// <summary>
        /// Add UserAttachment
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost("{userId}/Attachments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddAttachment(string userId, UserAttachmentRequest request)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));

                var address = _mapper.Map<UserAttachment>(request);
                address.UserId = user.Id;
                var entity = await _unitOfWork.UserAttachments.AddAsync(address);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<string>.SuccessAsync(entity.Entity.Id.ToString(), "Attachment successfully Added."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get UserAttachments
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>list of UserAttachmentResponse</returns>
        [HttpGet("{userId}/Attachments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserAttachmentResponse>))]
        public async Task<IActionResult> GetAttachments(string userId)
        {
            try
            {

                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var attachments = await _unitOfWork.UserAttachments.GetAllAsync(
                    predicate: x => x.UserId.ToString().Equals(userId),
                    orderBy: o => o.OrderBy(x => x.Order));


                var response = _mapper.Map<List<UserAttachmentResponse>>(attachments);

                return Ok(await Result<List<UserAttachmentResponse>>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }



        /// <summary>
        /// Get UserAttachment
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>UserAttachmentResponse</returns>
        [HttpGet("{userId}/Attachments/{attachmenteId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserAttachmentResponse))]
        public async Task<IActionResult> GetAttachment(string userId, string attachmenteId)
        {
            try
            {

                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var attachment = await _unitOfWork.UserAttachments.GetFirstOrDefaultAsync(
                    predicate: x => x.UserId.ToString().Equals(userId) && x.Id.ToString().Equals(attachmenteId));

                if (attachment is null)
                    return NotFound(await Result.FailAsync("Attachment not found."));


                var response = _mapper.Map<UserAttachmentResponse>(attachment);

                return Ok(await Result<UserAttachmentResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Delete UserAttachment
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>bool</returns>
        [HttpDelete("{userId}/Attachments/{attachmenteId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteAttachment(string userId, string attachmenteId)
        {
            try
            {
                if (userId is null)
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));


                var attachment = await _unitOfWork.UserAttachments.GetFirstOrDefaultAsync(
                    predicate: x => x.UserId.ToString().Equals(userId) && x.Id.ToString().Equals(attachmenteId));

                if (attachment is null)
                    return NotFound(await Result.FailAsync("Attachment not found."));

                _unitOfWork.UserAttachments.Remove(attachment);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<bool>.SuccessAsync(true, "Attachment successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        #endregion

    }
}
