using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WRMC.Core.Application.DataServices;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork;
using WRMC.Server.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WRMC.Server.Controllers
{
    [Route("api/v1/server/tenants")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;


        public TenantController(IMapper mapper,
            IHostEnvironment hostEnvironment,
            IConfiguration configuration,
            IUnitOfWork hostUnitOfWork)
        {
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
            _configuration = configuration;
            _unitOfWork = hostUnitOfWork;
        }

        /// <summary>
        /// Get list of tenants
        /// </summary>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="paged"></param>
        /// <returns>List or paged list of TenantResponse</returns>
        /// 
        [HttpGet()]

        public async Task<IActionResult> GetTenants(string? query = null, int page = 0, int pageSize = 10, bool paged = true)
        {

            if (paged)
            {
                var tenants = await _unitOfWork.Tenants.GetPagedListAsync(
                predicate: x => ((!string.IsNullOrWhiteSpace(query) ? x.Name.Contains(query) : true)
                || (!string.IsNullOrWhiteSpace(query) ? x.ExpireDate.ToString().Contains(query) : true)),
                include: i => i.Include(x => x.UserTenants),
                orderBy: o => o.OrderByDescending(k => k.CreatedDate),
                pageIndex: Convert.ToInt32(page),
                pageSize: Convert.ToInt32(pageSize) > 100 ? 100 : Convert.ToInt32(pageSize));
                var response = _mapper.Map<PagedList<TenantResponse>>(tenants);
                return Ok(await Result<IPagedList<TenantResponse>>.SuccessAsync(response));

            }
            else
            {
                var tenants = await _unitOfWork.Tenants.GetAllAsync(
                predicate: x => ((!string.IsNullOrWhiteSpace(query) ? x.Name.Contains(query) : true)
                || (!string.IsNullOrWhiteSpace(query) ? x.ExpireDate.ToString().Contains(query) : true)),
                orderBy: o => o.OrderByDescending(k => k.CreatedDate),
                include: i => i.Include(x => x.UserTenants));

                var response = _mapper.Map<List<TenantResponse>>(tenants);
                return Ok(await Result<IList<TenantResponse>>.SuccessAsync(response));
            }

        }

        /// <summary>
        /// Get tenant by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TenantResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TenantResponse))]
        public async Task<IActionResult> GetTenantById(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var tenant = await _unitOfWork.Tenants.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(id));

            var response = _mapper.Map<TenantResponse>(tenant);
            return Ok(await Result<TenantResponse>.SuccessAsync(response));

        }


        /// <summary>
        /// Check If Tenant Name Exist
        /// </summary>
        /// <param name="name"></param>
        /// <returns>bool</returns>
        [HttpGet("names")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> CheckIfTenantNameExist(string name)
        {

            if (string.IsNullOrWhiteSpace(name))
                return BadRequest(await Result.FailAsync("Invalid request."));

            var exist = await _unitOfWork.Tenants.AnyAsync(x => x.Name.Equals(name));

            
            return Ok(await Result<bool>.SuccessAsync(exist));

        }



        /// <summary>
        /// Get list of users by tenantId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of UserResponse</returns>
        [HttpGet("{id}/users")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserResponse>))]
        public async Task<IActionResult> GetUsersByTenantId(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var tenant = await _unitOfWork.Tenants.FindAsync(Guid.Parse(id));

            if (tenant == null)
                return NotFound(await Result.FailAsync("Tenant not found."));

            var users = await _unitOfWork.UserTenants.GetAllAsync(predicate: x => x.TenantId.ToString().Equals(id));
            var response = _mapper.Map<List<UserResponse>>(users);

            return Ok(await Result<IList<UserResponse>>.SuccessAsync(response));

        }


        /// <summary>
        /// Add new tenant 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>string(TenantId)</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddTenant(TenantRequest request)
        {
            if (await _unitOfWork.Tenants.AnyAsync(x => x.Name.Equals(request.Name)))
                return Conflict(await Result.FailAsync("The Name is already defined."));

            var tenant = _mapper.Map<Tenant>(request);
            await _unitOfWork.Tenants.AddAsync(tenant);
            await _unitOfWork.ServerDbContext.SaveChangesAsync();

            return Ok(await Result<string>.SuccessAsync(data: tenant.Id.ToString()));

        }

        /// <summary>
        /// Assign user to tenant
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="userId"></param>
        /// <returns>string(UserTenantId)</returns>
        [HttpPost("{tenantId}/users/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AssignUserToTenant(string tenantId, string userId)
        {

            if (string.IsNullOrWhiteSpace(tenantId))
                return BadRequest(await Result.FailAsync("TenantId is null or empty."));

            if (string.IsNullOrWhiteSpace(userId))
                return BadRequest(await Result.FailAsync("UserId is null or empty."));

            if ((await _unitOfWork.Tenants.FindAsync(tenantId)) == null)
                return NotFound(await Result.FailAsync("The tenant is not found."));

            if ((await _unitOfWork.Users.FindAsync(userId)) == null)
                return NotFound(await Result.FailAsync("The user is not found."));

            var tenant = await _unitOfWork.UserTenants.AddAsync(new UserTenant { TenantId = Guid.Parse(tenantId), UserId = Guid.Parse(userId) });
            await _unitOfWork.ServerDbContext.SaveChangesAsync();

            return Ok(await Result<string>.SuccessAsync(data: tenant.Entity.Id.ToString()));

        }

        /// <summary>
        /// Remove user from tenant
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("{tenantId}/users/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveUserFromTenant(string tenantId, string userId)
        {
            if (string.IsNullOrWhiteSpace(tenantId))
                return BadRequest(await Result.FailAsync("TenantId is null or empty."));

            if (string.IsNullOrWhiteSpace(userId))
                return BadRequest(await Result.FailAsync("UserId is null or empty."));

            var userTenant = await _unitOfWork.UserTenants.GetFirstOrDefaultAsync(
                predicate: x => x.UserId.ToString().Equals(userId) && x.TenantId.ToString().Equals(tenantId));

            if (userTenant == null)
                return BadRequest(await Result.FailAsync("tenant or user not found."));

            _unitOfWork.UserTenants.Remove(userTenant);
            await _unitOfWork.ServerDbContext.SaveChangesAsync();

            return Ok(await Result.SuccessAsync("User has been removed from tenant."));

        }

        /// <summary>
        /// Delete UserTenant by id
        /// </summary>
        /// <param name="id">id of userTenant</param>
        /// <returns></returns>
        [HttpDelete("user-tenants/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUserTenantById(string id)
        {

            if (string.IsNullOrWhiteSpace(id)) return BadRequest(await Result.FailAsync("Invalid request id."));

            var userTenant = await _unitOfWork.UserTenants.FindAsync(Guid.Parse(id));
            if (userTenant == null)
                return NotFound(await Result.FailAsync("UserTenant not found."));

            _unitOfWork.UserTenants.Remove(userTenant);
            await _unitOfWork.ServerDbContext.SaveChangesAsync();

            return Ok(await Result.SuccessAsync("UserTenant has been deleted."));

        }

        /// <summary>
        /// Delete tenant by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteTenantById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var tenant = await _unitOfWork.Tenants.FindAsync(Guid.Parse(id));
            if (tenant is null)
                return NotFound(await Result.FailAsync("The Tenant not found."));

            _unitOfWork.Tenants.Remove(tenant);
            await _unitOfWork.ServerDbContext.SaveChangesAsync();

            return Ok(await Result.SuccessAsync("Tenant successfully deleted"));

        }

        /// <summary>
        /// Update tenant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateTenantById(string id, JsonPatchDocument<TenantRequest> request)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var tenant = await _unitOfWork.Tenants.FindAsync(Guid.Parse(id));
            if (tenant is null)
                return NotFound(await Result.FailAsync("The Tenant not found."));

            var requestToPatch = _mapper.Map<TenantRequest>(tenant);
            request.ApplyTo(requestToPatch);
            _mapper.Map(requestToPatch, tenant);
            _unitOfWork.Tenants.Update(tenant);
            await _unitOfWork.ServerDbContext.SaveChangesAsync();

            return Ok(await Result.SuccessAsync("Tenant successfully updated"));

        }

        /// <summary>
        /// Replace tenant users
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{id}/users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateTenantUsers(string id, [FromBody] List<string> request)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var tenant = await _unitOfWork.Tenants.FindAsync(Guid.Parse(id));
            if (tenant is null)
                return NotFound(await Result.FailAsync("The Tenant not found."));

            _unitOfWork.UserTenants.RemoveRange(predicate: x => x.TenantId.ToString().Equals(id));
            foreach (var item in request)
            {
                if (item is not null)
                    await _unitOfWork.UserTenants.AddAsync(new UserTenant { UserId = Guid.Parse(item), TenantId = tenant.Id });
            }
            await _unitOfWork.ServerDbContext.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, "Users successfully replaced."));

        }

        /// <summary>
        /// Create Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}/ensure-created")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateDatabase(string id)
        {
            try
            {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

                var tenant = await _unitOfWork.Tenants.FindAsync(Guid.Parse(id));
                if (tenant is null)
                    return NotFound(await Result.FailAsync("Tenant not found."));

                tenant.ConnectionString = string.Format(tenant.ConnectionString, id);
                await _unitOfWork.ServerDbContext.SaveChangesAsync();

            _unitOfWork.TenantDbContext.Database.SetConnectionString(tenant.ConnectionString);
            TenantDbContext.ConnectionString = tenant.ConnectionString;
            var result = await _unitOfWork.TenantDbContext.Database.EnsureCreatedAsync();
            if (result)
                return Ok(await Result.SuccessAsync("Database created successfully."));
            else
                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync("Create database failed."));

           

        }

        /// <summary>
        /// Migrate Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}/migrate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> MigrateDatabase(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var tenant = await _unitOfWork.Tenants.FindAsync(Guid.Parse(id));
            if (tenant is null)
                return NotFound(await Result.FailAsync("Tenant not found."));

            _unitOfWork.TenantDbContext.Database.SetConnectionString(tenant.ConnectionString);
            await _unitOfWork.TenantDbContext.Database.MigrateAsync();
            return Ok(await Result.SuccessAsync("Database migrated successfully."));
        }


        /// <summary>
        /// Delete Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}/ensure-deleted")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteDatabase(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var tenant = await _unitOfWork.Tenants.FindAsync(Guid.Parse(id));
            if (tenant is null)
                return NotFound(await Result.FailAsync("Tenant not found."));


            _unitOfWork.TenantDbContext.Database.SetConnectionString(tenant.ConnectionString);
            var result = await _unitOfWork.TenantDbContext.Database.EnsureDeletedAsync();
            if (result)
                return Ok(await Result.SuccessAsync("Database deleted successfully."));
            else
                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync("delete database failed."));


        }

    }
}
