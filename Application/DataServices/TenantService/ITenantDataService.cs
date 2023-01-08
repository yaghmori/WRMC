using Microsoft.AspNetCore.JsonPatch;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{
    public interface ITenantDataService
    {
        Task<IResult<string>> AddTenantAsync(TenantRequest request);
        Task<IResult<List<TenantResponse>>> GetTenantsAsync(string? query = null);
        Task<IResult<IPagedList<TenantResponse>>> GetTenantsPagedAsync(int page = 0, int pageSize = 10, string query = null);
        Task<IResult<string>> AddTenantUserAsync(string tenantId, string userId);
        Task<IResult<bool>> DeleteTenantByIdAsync(string tenantId);
        Task<IResult<TenantResponse>> GetTenantByIdAsync(string tenantId);
        Task<IResult<List<UserResponse>>> GetTenantUsersAsync(string tenantId);
        Task<IResult<bool>> DeleteTenantUserAsync(string tenantId, string userId);
        Task<IResult<bool>> DeleteTenantUserAsync(string tenantId);
        Task<IResult<bool>> UpdateTenantUsersAsync(string tenantId, List<string> users);
        Task<IResult<bool>> UpdateTenantByIdAsync(string tenantId, JsonPatchDocument<TenantRequest> request);
        Task<IResult<bool>> CreateDatabaseAsync(string tenantId);
        Task<IResult<bool>> DeleteDatabaseAsync(string tenantId);
        Task<IResult<bool>> MigrateDatabaseAsync(string tenantId);
        Task<IResult<bool>> CheckIfNameExist(string name);


    }
}