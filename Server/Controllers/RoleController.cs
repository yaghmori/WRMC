using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Azure.Core.GeoJson;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork;
using WRMC.Server.Extensions;

namespace WRMC.Server.Controllers
{
    [Route("api/v1/server/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ServerDbContext> _unitOfWork;

        public RoleController(IMapper mapper, ServerDbContext context, IUnitOfWork<ServerDbContext> unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add New Role
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns>RoleId as string</returns>
        [HttpPost("{roleName}")]
        
        public async Task<IActionResult> AddRole(string roleName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleName))
                    return BadRequest(await Result.FailAsync("RoleName is null or empty."));
                if (await _unitOfWork.Roles.AnyAsync(x => x.Name.Equals(roleName)))
                    return Conflict(await Result.FailAsync("The role name is already defined."));
                var role = new Role(roleName);
                role.NormalizedName = roleName.Normalize().ToUpper();
                await _unitOfWork.Roles.AddAsync(role);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<string>.SuccessAsync(data: role.Id.ToString(), message: "Role successfully created."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Delete Role by Name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        [HttpDelete("Name/{roleName}")]
        public async Task<IActionResult> DeleteRoleByName(string roleName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleName))
                    return BadRequest(await Result.FailAsync("RoleName is null or empty."));

                var role = await _unitOfWork.Roles.GetFirstOrDefaultAsync(predicate: x => x.Name.Equals(roleName));
                if (role is null)
                    return NotFound(await Result.FailAsync("Role not found."));

                _unitOfWork.Roles.Remove(role);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "Role successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Dlete Role
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>OK</returns>
        [HttpDelete("{roleId}")]
        public async Task<IActionResult> DeleteRoleById(string roleId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleId))
                    return BadRequest(await Result.FailAsync("RoleId is null or empty."));

                var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(roleId));
                if (role is null) NotFound(await Result.FailAsync("Role not found."));

                _unitOfWork.Roles.Remove(role);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "Role successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Update Role 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="roleName"></param>
        /// <returns>OK</returns>
        [HttpPatch("{roleId}")]
        public async Task<IActionResult> UpdateRoleById(string roleId, string roleName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleId))
                    return BadRequest(await Result.FailAsync("RoleId is null or empty."));

                if (string.IsNullOrWhiteSpace(roleName))
                    return BadRequest(await Result.FailAsync("RoleName is null or empty."));

                var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(roleId));
                if (role is null)
                    return NotFound(await Result.FailAsync("Role not found"));

                role.Name = roleName;
                role.NormalizedName = roleName.Normalize().ToUpper();
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "Role successfully updated."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Get All Roles 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="paged"></param>
        /// <returns>List of RoleResponse</returns>
        [HttpGet]
        public async Task<IActionResult> GetRoles(string? query = null, int page = 0, int pageSize = 10, bool paged = true)
        {
            try
            {
                if (paged)
                {
                    var roles = await _unitOfWork.Roles.GetPagedListAsync(
                    predicate: x => ((!string.IsNullOrWhiteSpace(query) ? x.Name.Contains(query) : true)),
                    include:i=>i.Include(x=>x.RoleClaims).Include(x=>x.UserRoles),
                    orderBy: o => o.OrderByDescending(k => k.CreatedDate),
                    pageIndex: Convert.ToInt32(page),
                    pageSize: Convert.ToInt32(pageSize) > 100 ? 100 : Convert.ToInt32(pageSize));
                    var response = _mapper.Map<PagedList<RoleResponse>>(roles);
                    var a = await Result<IPagedList<RoleResponse>>.SuccessAsync(response);
                    return Ok(a);

                }
                else
                {
                    var roles = await _unitOfWork.Roles.GetAll(
                        predicate: x => ((!string.IsNullOrWhiteSpace(query) ? x.Name.Contains(query) : true)),
                        include: i => i.Include(x => x.RoleClaims).Include(x => x.UserRoles),
                    orderBy: o => o.OrderByDescending(k => k.CreatedDate)).ToListAsync();
                    var response = _mapper.Map<List<RoleResponse>>(roles);

                    return Ok(await Result<List<RoleResponse>>.SuccessAsync(response));
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Get Role by Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>RoleResponse</returns>
        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetRoleById(string roleId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleId))
                    return BadRequest(await Result.FailAsync("RoleId is null or empty."));

                var role = await _unitOfWork.Roles.GetFirstOrDefaultAsync(
                    include: i => i.Include(x => x.RoleClaims).Include(x => x.UserRoles).ThenInclude(x => x.User),
                    predicate: x => x.Id.ToString().Equals(roleId));

                if (role is null)
                    return NotFound(await Result.FailAsync("Role not found"));

                var response = _mapper.Map<RoleResponse>(role);
                return Ok(await Result<RoleResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Get Role by Name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns>RoleResponse</returns>
        [HttpGet("Name/{roleName}")]
        public async Task<IActionResult> GetRoleByName(string roleName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleName))
                    return BadRequest(await Result.FailAsync("RoleName is null or empty."));

                var role = await _unitOfWork.Roles.GetFirstOrDefaultAsync(
                    include: i => i.Include(x => x.RoleClaims).Include(x => x.UserRoles).ThenInclude(x => x.User),
                    predicate: x => x.Name.Equals(roleName));

                if (role is null)
                    return NotFound(await Result.FailAsync("Role not found"));

                var response = _mapper.Map<RoleResponse>(role);
                return Ok(await Result<RoleResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Get UserRoles by RoleName
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns>List of UserResponse</returns>

        [HttpGet("Name/{roleName}/users")]
        public async Task<IActionResult> GetUsersByRoleName(string roleName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleName))
                    return BadRequest(await Result.FailAsync("RoleName is null or empty."));

                var role = await _unitOfWork.Roles.GetFirstOrDefaultAsync(predicate: x => x.Name.Equals(roleName));

                if (role is null)
                    return NotFound(await Result.FailAsync("Role not found"));

                var roleUsers = await _unitOfWork.UserRoles.GetAllAsync(predicate: x => x.RoleId == role.Id);
                var response = _mapper.Map<List<BaseUserResponse>>(roleUsers);
                return Ok(await Result<List<BaseUserResponse>>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Add UserRole
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns>UserRoleId as string</returns>
        [HttpPost("{roleId}/users/{userId}")]
        public async Task<IActionResult> AssignUserToRole(string roleId, string userId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleId))
                    return BadRequest(await Result.FailAsync("RoleId is null or empty."));

                if (string.IsNullOrWhiteSpace(userId))
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));

                var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(roleId));
                if (role is null)
                    return NotFound(await Result.FailAsync("Role not found."));

                var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
                if (user is null)
                    return NotFound(await Result.FailAsync("User not found."));


                var userRoles = await _unitOfWork.UserRoles.AddAsync(new UserRole(user.Id, role.Id));
               await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true,"Role successfully assigned to user."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Delete UserRole
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns>bool</returns>
        [HttpDelete("{roleId}/users/{userId}")]
        public async Task<IActionResult> RemoveUserFromRole(string roleId, string userId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleId))
                    return BadRequest(await Result.FailAsync("RoleId is null or empty."));

                if (string.IsNullOrWhiteSpace(userId))
                    return BadRequest(await Result.FailAsync("UserId is null or empty."));



                var userRoles = await _unitOfWork.UserRoles.GetFirstOrDefaultAsync(predicate:x=>x.UserId.ToString().Equals(userId) && x.RoleId.ToString().Equals(roleId));
                if (userRoles is null)
                    return NotFound(await Result.FailAsync("userRole not found."));

                _unitOfWork.UserRoles.Remove(userRoles);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "userRole successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Add RoleClaim
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>RoleClaimId as string</returns>
        [HttpPost("{roleId}/claims")]
        public async Task<IActionResult> AddRoleClaim(string roleId, ClaimRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleId))
                    return BadRequest(await Result.FailAsync("RoleId is null or empty."));


                var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(roleId));
                if (role is null)
                    return NotFound(await Result.FailAsync("Role not found."));



                var userRoles = await _unitOfWork.RoleClaims.AddAsync(new RoleClaim
                {
                    ClaimType = request.ClaimType,
                    ClaimValue = request.ClaimValue,
                    RoleId = role.Id
                });
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<string>.SuccessAsync(userRoles.Entity.Id.ToString(), "Claim successfully added to role."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Delete RoleClaim
        /// </summary>
        /// <param name="roleClaimId"></param>
        /// <returns>bool</returns>
        [HttpDelete("claims/{roleClaimId}")]
        public async Task<IActionResult> DeleteRoleClaim(string roleClaimId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleClaimId))
                    return BadRequest(await Result.FailAsync("RoleClaimId is null or empty."));

                var roleClaim = await _unitOfWork.RoleClaims.FindAsync(Convert.ToInt32(roleClaimId));
                if (roleClaim is null)
                    return NotFound(await Result.FailAsync("RoleClaim not found."));

                //TODO : find unchanged problem
               _unitOfWork.RoleClaims.Remove(roleClaim);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "RoleClaim successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get RoleUsers
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>List of UserResponse</returns>
        [HttpGet("{roleId}/users")]
        public async Task<IActionResult> GetUsersByRoleId(string roleId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleId))
                    return BadRequest(await Result.FailAsync("RoleId is null or empty."));

                var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(roleId));
                if (role is null)
                    return NotFound(await Result.FailAsync("Role not found"));

                var userRoles = await _unitOfWork.UserRoles.GetAllAsync(
                    predicate: x => x.RoleId == role.Id,
                    include: i => i.Include(x => x.User));
                var response = _mapper.Map<List<BaseUserResponse>>(userRoles);
                return Ok(await Result<List<BaseUserResponse>>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Get RoleClaims
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>List of claimResponse</returns>
        [HttpGet("{roleId}/claims")]
        public async Task<IActionResult> GetRoleClaims(string roleId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleId))
                    return BadRequest(await Result.FailAsync("RoleId is null or empty."));

                var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(roleId));
                if (role is null)
                    return NotFound(await Result.FailAsync("Role not found"));

                var roleClaims = await _unitOfWork.RoleClaims.GetAllAsync(
                     predicate: x => x.RoleId.ToString().Equals(roleId));

                var response = _mapper.Map<List<RoleClaimResponse>>(roleClaims);
                return Ok(await Result<List<RoleClaimResponse>>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Update RoleUsers
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="request"></param>
        /// <returns>OK</returns>
        [HttpPut("{roleId}/Users")]
        public async Task<IActionResult> UpdateRoleUsers(string roleId, [FromBody] List<string> request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleId))
                    return BadRequest(await Result.FailAsync("RoleId is null or empty."));

                var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(roleId));
                if (role is null)
                    return NotFound(await Result.FailAsync("Role not found."));

                _unitOfWork.UserRoles.RemoveRange(predicate: x => x.RoleId == role.Id);
                foreach (var item in request)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        await _unitOfWork.UserRoles.AddAsync(new UserRole { UserId = Guid.Parse(item), RoleId = role.Id });
                    }

                }

                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "RoleUsers successfully updated."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Update RoleClaims
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="request"></param>
        /// <returns>OK</returns>
        [HttpPut("{roleId}/claims")]
        public async Task<IActionResult> UpdateRoleClaims(string roleId, [FromBody] List<ClaimRequest> request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleId))
                    return BadRequest(await Result.FailAsync("RoleId is null or empty."));

                var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(roleId));
                if (role is null)
                    return NotFound(await Result.FailAsync("Role not found."));

                _unitOfWork.RoleClaims.RemoveRange(predicate: x => x.RoleId == role.Id);
                foreach (var item in request)
                {
                    if (item is not null)
                        await _unitOfWork.RoleClaims.AddAsync(new RoleClaim { RoleId = role.Id, ClaimType = item.ClaimType, ClaimValue = item.ClaimValue });
                }
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "RoleClaims successfully updated."));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }
    }

}

