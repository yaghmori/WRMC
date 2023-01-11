using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{
    public interface IRoleDataService
    {
        Task<IResult<string>> AddRoleAsync(string roleName);
        Task<IResult<bool>> DeleteRoleAsync(string roleId);
        Task<IResult<RoleResponse>> GetRoleAsync(string roleId);
        Task<IResult<List<RoleResponse>>> GetRolesAsync(string? query = null, string? userId = null);
        Task<IResult<List<ClaimResponse>>> GetRoleClaimsAsync(string roleId);
        Task<IResult<IPagedList<RoleResponse>>> GetRolesPagedAsync(int page = 0, int pageSize = 10, string query = null);
        Task<IResult<List<BaseUserResponse>>> GetRoleUsersAsync(string roleId);
        Task<IResult<bool>> CheckIfNameExist(string name);
        Task<IResult<bool>> UpdateUserRolesAsync(string roleId, List<string> users);
        Task<IResult<bool>> UpdateRoleAsync(string roleId, string roleName);
        Task<IResult<bool>> UpdateRoleClaimsAsync(string roleId, List<ClaimResponse> claims);
    }
}