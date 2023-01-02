using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using WRMC.Core.Application.Extensions;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{
    public class RoleDataService : DataServiceBase, IRoleDataService
    {
        public RoleDataService(IHttpClientFactory httpClient) : base(httpClient)
        {
        }

        public async Task<IResult<List<RoleResponse>>> GetRolesAsync(string? query = null, string? userId = null)
        {
            var uri = EndPoints.RoleController.GetRoles;
            uri = QueryHelpers.AddQueryString(uri, "paged", "false");
            if (!string.IsNullOrWhiteSpace(query))
                uri = QueryHelpers.AddQueryString(uri, nameof(query), query);

            if (!string.IsNullOrWhiteSpace(userId))
                uri = QueryHelpers.AddQueryString(uri, nameof(userId), userId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<List<RoleResponse>>();
        }

        public async Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsAsync(string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId))
                return await Result<List<RoleClaimResponse>>.FailAsync("RoleId is null or empty.");

            string uri = string.Format(EndPoints.RoleController.GetRoleClaims, roleId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<List<RoleClaimResponse>>();
        }

        public async Task<IResult<IPagedList<RoleResponse>>> GetRolesPagedAsync(int page = 0, int pageSize = 10, string query = null)
        {
            var uri = EndPoints.RoleController.GetRoles;

            //uri = QueryHelpers.AddQueryString(uri, "paged", "true");

            uri = QueryHelpers.AddQueryString(uri, "page", page.ToString());
            uri = QueryHelpers.AddQueryString(uri, "pageSize", pageSize.ToString());
            if (!string.IsNullOrWhiteSpace(query))
                uri = QueryHelpers.AddQueryString(uri, nameof(query), query);

            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<PagedList<RoleResponse>>();
        }

        public async Task<IResult<List<BaseUserResponse>>> GetUserRolesAsync(string roleId)
        {

            if (string.IsNullOrWhiteSpace(roleId))
                return await Result<List<BaseUserResponse>>.FailAsync("RoleId is null or empty.");

            string uri = string.Format(EndPoints.RoleController.GetUsersByRoleId, roleId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<List<BaseUserResponse>>();
        }

        public async Task<IResult<RoleResponse>> GetRoleAsync(string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId))
                return await Result<RoleResponse>.FailAsync("RoleId is null or empty.");

            string uri = string.Format(EndPoints.RoleController.GetRoleById, roleId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<RoleResponse>();
        }

        public async Task<IResult<string>> AddRoleAsync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return await Result<string>.FailAsync("RoleName is null or empty.");

            string uri = string.Format(EndPoints.RoleController.AddRole, roleName);


            var content = new StringContent(JsonConvert.SerializeObject(roleName), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }

        public async Task<IResult<bool>> DeleteRoleAsync(string roleId)
        {

            if (string.IsNullOrWhiteSpace(roleId))
                return await Result<bool>.FailAsync("RoleId is null or empty.");

            string uri = string.Format(EndPoints.RoleController.DeleteRoleById, roleId);


            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }


        public async Task<IResult<bool>> UpdateRoleAsync(string roleId, string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleId))
                return await Result<bool>.FailAsync("RoleId is null or empty.");

            var uri = string.Format(EndPoints.RoleController.UpdateRoleById, roleId);
            uri = QueryHelpers.AddQueryString(uri, nameof(roleName), roleName);

            var response = await _httpClient.PatchAsync(uri, null);
            return await response.ToResult<bool>();
        }


        public async Task<IResult<bool>> UpdateUserRolesAsync(string roleId, List<string> users)
        {

            if (string.IsNullOrWhiteSpace(roleId))
                return await Result<bool>.FailAsync("RoleId is null or empty.");

            var uri = string.Format(EndPoints.RoleController.UpdateUserRoles, roleId);

            var content = new StringContent(JsonConvert.SerializeObject(users), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(uri, content);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> UpdateRoleClaimsAsync(string roleId, List<ClaimResponse> claims)
        {

            if (string.IsNullOrWhiteSpace(roleId))
                return await Result<bool>.FailAsync("RoleId is null or empty.");

            var uri = string.Format(EndPoints.RoleController.UpdateRoleClaims, roleId);

            var content = new StringContent(JsonConvert.SerializeObject(claims), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(uri, content);
            return await response.ToResult<bool>();
        }

    }
}
