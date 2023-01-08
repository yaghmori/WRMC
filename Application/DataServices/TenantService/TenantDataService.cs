using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using WRMC.Core.Application.Extensions;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Infrastructure.Domain.Entities;

namespace WRMC.Core.Application.DataServices
{


    public class TenantDataService : DataServiceBase, ITenantDataService
    {

        public TenantDataService(IHttpClientFactory httpClient) : base(httpClient)
        {
        }


        public async Task<IResult<string>> AddTenantAsync(TenantRequest request)
        {
            var uri = EndPoints.TenantController.AddTenant;

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
           var a= await response.ToResult<string>();
            return a;
        }

        public async Task<IResult<List<TenantResponse>>> GetTenantsAsync(string? query = null)
        {
            var uri = EndPoints.TenantController.GetTenants;
            uri = QueryHelpers.AddQueryString(uri, "paged", "false");
            if (!string.IsNullOrWhiteSpace(query))
                uri = QueryHelpers.AddQueryString(uri, nameof(query), query);

            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<List<TenantResponse>>();
        }


        public async Task<IResult<bool>> CheckIfNameExist(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return await Result<bool>.FailAsync("Invalid request.");

            var uri = EndPoints.TenantController.CheckIfNameExist;
            uri = QueryHelpers.AddQueryString(uri, nameof(name), name);

            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<bool>();
        }



        public async Task<IResult<IPagedList<TenantResponse>>> GetTenantsPagedAsync(int page = 0, int pageSize = 10, string query = null)
        {
            var uri = EndPoints.TenantController.GetTenants;
            uri = QueryHelpers.AddQueryString(uri, "page", page.ToString());
            uri = QueryHelpers.AddQueryString(uri, "pageSize", pageSize.ToString());
            if (!string.IsNullOrWhiteSpace(query))
                uri = QueryHelpers.AddQueryString(uri, nameof(query), query);


            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<PagedList<TenantResponse>>();
        }

        public async Task<IResult<TenantResponse>> GetTenantByIdAsync(string tenantId)
        {
            if (string.IsNullOrWhiteSpace(tenantId))
                return await Result<TenantResponse>.FailAsync("TenantId is null or empty.");


            var uri = string.Format(EndPoints.TenantController.GetTenantById, tenantId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<TenantResponse>();
        }

        public async Task<IResult<bool>> DeleteTenantByIdAsync(string tenantId)
        {

            if (string.IsNullOrWhiteSpace(tenantId))
                return await Result<bool>.FailAsync("TenantId is null or empty.");

            var uri = string.Format(EndPoints.TenantController.DeleteTenantById, tenantId);

            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> DeleteTenantUserAsync(string tenantId)
        {

            if (string.IsNullOrWhiteSpace(tenantId))
                return await Result<bool>.FailAsync("TenantId is null or empty.");

            var uri = string.Format(EndPoints.TenantController.DeleteUserTenantById, tenantId);

            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<string>> AddTenantUserAsync(string tenantId, string userId)
        {
            string result = null;

            if (string.IsNullOrWhiteSpace(tenantId))
                return await Result<string>.FailAsync("TenantId is null or empty.");

            if (string.IsNullOrWhiteSpace(userId))
                return await Result<string>.FailAsync("UserId is null or empty.");


            var uri = string.Format(EndPoints.TenantController.AddUserToTenant, tenantId, userId);

            var response = await _httpClient.PostAsync(uri, null);
            return await response.ToResult<string>();

        }

        public async Task<IResult<bool>> DeleteTenantUserAsync(string tenantId, string userId)
        {
            var uri = string.Format(EndPoints.TenantController.RemoveUserFromTenant, tenantId, userId);
            bool result = false;

            if (string.IsNullOrWhiteSpace(tenantId))
                return await Result<bool>.FailAsync("TenantId is null or empty.");

            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();

        }

        public async Task<IResult<bool>> UpdateTenantByIdAsync(string tenantId, JsonPatchDocument<TenantRequest> request)
        {

            if (string.IsNullOrWhiteSpace(tenantId))
                return await Result<bool>.FailAsync("TenantId is null or empty.");

            var uri = string.Format(EndPoints.TenantController.UpdateTenantById, tenantId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<List<UserResponse>>> GetTenantUsersAsync(string tenantId)
        {
            if (string.IsNullOrWhiteSpace(tenantId))
                return await Result<List<UserResponse>>.FailAsync("TenantId is null or empty.");

            var uri = string.Format(EndPoints.TenantController.GetUsersByTenantId, tenantId);


            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<List<UserResponse>>();

        }

        public async Task<IResult<bool>> UpdateTenantUsersAsync(string tenantId, List<string> users)
        {
            if (string.IsNullOrWhiteSpace(tenantId))
                return await Result<bool>.FailAsync("TenantId is null or empty.");

            var uri = string.Format(EndPoints.TenantController.ReplaceTenantUsers, tenantId);

            var content = new StringContent(JsonConvert.SerializeObject(users), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> CreateDatabaseAsync(string tenantId)
        {
            if (string.IsNullOrWhiteSpace(tenantId))
                return await Result<bool>.FailAsync("TenantId is null or empty.");

            var uri = string.Format(EndPoints.TenantController.CreateDataBase, tenantId);


            var response = await _httpClient.PostAsync(uri, null);
            var a =  await response.ToResult<bool>();
            return a;
        }

        public async Task<IResult<bool>> MigrateDatabaseAsync(string tenantId)
        {
            if (string.IsNullOrWhiteSpace(tenantId))
                return await Result<bool>.FailAsync("TenantId is null or empty.");

            var uri = string.Format(EndPoints.TenantController.MigrateDataBase, tenantId);

            var response = await _httpClient.PostAsync(uri, null);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> DeleteDatabaseAsync(string tenantId)
        {

            if (string.IsNullOrWhiteSpace(tenantId))
                return await Result<bool>.FailAsync("TenantId is null or empty.");

            var uri = string.Format(EndPoints.TenantController.DeleteDataBase, tenantId);

            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

    }
}
