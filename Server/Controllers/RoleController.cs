using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Azure.Core.GeoJson;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork;
using WRMC.Server.Extensions;
using WRMC.Core.Shared.Responses;

namespace WRMC.Server.Controllers
{
    [Route("api/v1/server/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RoleController(IMapper mapper, IUnitOfWork unitOfWork)
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

            if (string.IsNullOrWhiteSpace(roleName))
                return BadRequest(await Result.FailAsync("RoleName is null or empty."));
            if (await _unitOfWork.Roles.AnyAsync(x => x.Name.Equals(roleName)))
                return Conflict(await Result.FailAsync("The role name is already defined."));
            var role = new Role(roleName);
            role.NormalizedName = roleName.Normalize().ToUpper();
            await _unitOfWork.Roles.AddAsync(role);
            await _unitOfWork.ServerDbContext.SaveChangesAsync();
            return Ok(await Result<string>.SuccessAsync(data: role.Id.ToString(), message: "Role successfully created."));
        }

        /// <summary>
        /// Delete Role by Name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        [HttpDelete("Name/{roleName}")]
        public async Task<IActionResult> DeleteRoleByName(string roleName)
        {

            if (string.IsNullOrWhiteSpace(roleName))
                return BadRequest(await Result.FailAsync("RoleName is null or empty."));

            var role = await _unitOfWork.Roles.GetFirstOrDefaultAsync(predicate: x => x.Name.Equals(roleName));
            if (role is null)
                return NotFound(await Result.FailAsync("Role not found."));

            _unitOfWork.Roles.Remove(role);
            await _unitOfWork.ServerDbContext.SaveChangesAsync();
            return Ok(await Result<bool>.SuccessAsync(true, "Role successfully deleted."));

        }

        /// <summary>
        /// Dlete Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns>OK</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleById(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(id));
            if (role is null) NotFound(await Result.FailAsync("Role not found."));

            _unitOfWork.Roles.Remove(role);
            await _unitOfWork.ServerDbContext.SaveChangesAsync();
            return Ok(await Result<bool>.SuccessAsync(true, "Role successfully deleted."));

        }

        /// <summary>
        /// Update Role 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleName"></param>
        /// <returns>OK</returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRoleById(string id, string roleName)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("RoleId is null or empty."));

            if (string.IsNullOrWhiteSpace(roleName))
                return BadRequest(await Result.FailAsync("RoleName is null or empty."));

            var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(id));
            if (role is null)
                return NotFound(await Result.FailAsync("Role not found"));

            role.Name = roleName;
            role.NormalizedName = roleName.Normalize().ToUpper();

            await _unitOfWork.ServerDbContext.SaveChangesAsync();
            return Ok(await Result<bool>.SuccessAsync(true, "Role successfully updated."));
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

            if (paged)
            {
                var roles = await _unitOfWork.Roles.GetPagedListAsync(
                predicate: x => ((!string.IsNullOrWhiteSpace(query) ? x.Name.Contains(query) : true)),
                include: i => i.Include(x => x.RoleClaims).Include(x => x.UserRoles),
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

        /// <summary>
        /// Get Role by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>RoleResponse</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var role = await _unitOfWork.Roles.GetFirstOrDefaultAsync(
                include: i => i.Include(x => x.RoleClaims).Include(x => x.UserRoles).ThenInclude(x => x.User),
                predicate: x => x.Id.ToString().Equals(id));

            if (role is null)
                return NotFound(await Result.FailAsync("Role not found"));

            var response = _mapper.Map<RoleResponse>(role);
            return Ok(await Result<RoleResponse>.SuccessAsync(response));

        }

        /// <summary>
        /// Get Role by Name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns>RoleResponse</returns>
        [HttpGet("Name/{roleName}")]
        public async Task<IActionResult> GetRoleByName(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return BadRequest(await Result.FailAsync("RoleName is null or empty."));

            var role = await _unitOfWork.Roles.GetFirstOrDefaultAsync(
                include: i => i.Include(x => x.RoleClaims).Include(x => x.UserRoles).ThenInclude(x => x.User),
                predicate: x => x.Name.Equals(roleName));

            var response = _mapper.Map<RoleResponse>(role);
            return Ok(await Result<RoleResponse>.SuccessAsync(response));

        }

        /// <summary>
        /// Get UserRoles by RoleName
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns>List of UserResponse</returns>

        [HttpGet("Name/{roleName}/users")]
        public async Task<IActionResult> GetUsersByRoleName(string roleName)
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


        /// <summary>
        /// Add UserRole
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns>UserRoleId as string</returns>
        [HttpPost("{roleId}/users/{userId}")]
        public async Task<IActionResult> AssignUserToRole(string roleId, string userId)
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
            await _unitOfWork.ServerDbContext.SaveChangesAsync();
            return Ok(await Result<bool>.SuccessAsync(true, "Role successfully assigned to user."));

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

            if (string.IsNullOrWhiteSpace(roleId))
                return BadRequest(await Result.FailAsync("RoleId is null or empty."));

            if (string.IsNullOrWhiteSpace(userId))
                return BadRequest(await Result.FailAsync("UserId is null or empty."));



            var userRoles = await _unitOfWork.UserRoles.GetFirstOrDefaultAsync(predicate: x => x.UserId.ToString().Equals(userId) && x.RoleId.ToString().Equals(roleId));
            if (userRoles is null)
                return NotFound(await Result.FailAsync("userRole not found."));

            _unitOfWork.UserRoles.Remove(userRoles);
            await _unitOfWork.ServerDbContext.SaveChangesAsync();
            return Ok(await Result<bool>.SuccessAsync(true, "userRole successfully deleted."));

        }


        /// <summary>
        /// Add RoleClaim
        /// </summary>
        /// <param name="id"></param>
        /// <returns>RoleClaimId as string</returns>
        [HttpPost("{id}/claims")]
        public async Task<IActionResult> AddRoleClaim(string id, ClaimRequest request)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));


            var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(id));
            if (role is null)
                return NotFound(await Result.FailAsync("Role not found."));



            var userRoles = await _unitOfWork.RoleClaims.AddAsync(new RoleClaim
            {
                ClaimType = request.ClaimType,
                ClaimValue = request.ClaimValue,
                RoleId = role.Id
            });
            await _unitOfWork.ServerDbContext.SaveChangesAsync();

            return Ok(await Result<string>.SuccessAsync(userRoles.Entity.Id.ToString(), "Claim successfully added to role."));

        }


        /// <summary>
        /// Delete RoleClaim
        /// </summary>
        /// <param name="id">RoleClaimId</param>
        /// <returns>bool</returns>
        [HttpDelete("claims/{roleClaimId}")]
        public async Task<IActionResult> DeleteRoleClaim(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var roleClaim = await _unitOfWork.RoleClaims.FindAsync(Convert.ToInt32(id));
            if (roleClaim is null)
                return NotFound(await Result.FailAsync("RoleClaim not found."));

            //TODO : find unchanged problem
            _unitOfWork.RoleClaims.Remove(roleClaim);
            await _unitOfWork.ServerDbContext.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, "RoleClaim successfully deleted."));

        }


        /// <summary>
        /// Get RoleUsers
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of UserResponse</returns>
        [HttpGet("{id}/users")]
        public async Task<IActionResult> GetUsersByRoleId(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(id));
            if (role is null)
                return NotFound(await Result.FailAsync("Role not found"));

            var userRoles = await _unitOfWork.UserRoles.GetAllAsync(
                predicate: x => x.RoleId == role.Id,
                include: i => i.Include(x => x.User));
            var response = _mapper.Map<List<BaseUserResponse>>(userRoles);
            return Ok(await Result<List<BaseUserResponse>>.SuccessAsync(response));

        }

        /// <summary>
        /// Get RoleClaims
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of claimResponse</returns>
        [HttpGet("{id}/claims")]
        public async Task<IActionResult> GetRoleClaims(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(id));
            if (role is null)
                return NotFound(await Result.FailAsync("Role not found"));

            var roleClaims = await _unitOfWork.RoleClaims.GetAllAsync(
                 predicate: x => x.RoleId.ToString().Equals(id));

            var response = _mapper.Map<List<RoleClaimResponse>>(roleClaims);

            return Ok(await Result<List<RoleClaimResponse>>.SuccessAsync(response));

        }

        /// <summary>
        /// Update RoleUsers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>OK</returns>
        [HttpPut("{id}/Users")]
        public async Task<IActionResult> UpdateRoleUsers(string id, [FromBody] List<string> request)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(id));
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

            await _unitOfWork.ServerDbContext.SaveChangesAsync();
            return Ok(await Result<bool>.SuccessAsync(true, "RoleUsers successfully updated."));

        }

        /// <summary>
        /// Update RoleClaims
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>OK</returns>
        [HttpPut("{id}/claims")]
        public async Task<IActionResult> UpdateRoleClaims(string id, [FromBody] List<ClaimRequest> request)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var role = await _unitOfWork.Roles.FindAsync(Guid.Parse(id));
            if (role is null)
                return NotFound(await Result.FailAsync("Role not found."));

            _unitOfWork.RoleClaims.RemoveRange(predicate: x => x.RoleId == role.Id);
            foreach (var item in request)
            {
                if (item is not null)
                    await _unitOfWork.RoleClaims.AddAsync(new RoleClaim { RoleId = role.Id, ClaimType = item.ClaimType, ClaimValue = item.ClaimValue });
            }
            await _unitOfWork.ServerDbContext.SaveChangesAsync();
            return Ok(await Result<bool>.SuccessAsync(true, "RoleClaims successfully updated."));

        }
    }

}

