using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using WRMC.Core.Shared.Extensions;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Core.Shared.Constants;

namespace WRMC.Core.Application.DataServices
{


    public class AppSettingDataService : DataServiceBase, IAppSettingDataService
    {

        public AppSettingDataService(IHttpClientFactory httpClient) : base(httpClient)
        {
        }


        public async Task<IResult<bool>> DeleteAppSettingsByIdAsync(string appsettingId)
        {

            if (string.IsNullOrWhiteSpace(appsettingId))
                return await Result<bool>.FailAsync("AppSettingId is null or empty.");

            var uri = string.Format(EndPoints.AppSettingController.DeleteAppSettingById, appsettingId);

            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> DeleteAppSettingsByKeyAsync(string key)
        {

            if (string.IsNullOrWhiteSpace(key))
                return await Result<bool>.FailAsync("Key is null or empty.");

           var uri = QueryHelpers.AddQueryString(EndPoints.AppSettingController.DeleteAppSettingByKey, nameof(key), key);

            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<AppSettingsResponse>> GetAppSettingsByIdAsync(string appsettingId)
        {
            if (string.IsNullOrWhiteSpace(appsettingId))
                return await Result<AppSettingsResponse>.FailAsync("AppsettingId is null or empty.");


            var uri = string.Format(EndPoints.AppSettingController.GetAppSettingById, appsettingId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<AppSettingsResponse>();
        }

        public async Task<IResult<AppSettingsResponse>> GetAppSettingsByKeyAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return await Result<AppSettingsResponse>.FailAsync("Key is null or empty.");

            var uri = QueryHelpers.AddQueryString(EndPoints.AppSettingController.GetAppSettingByKey, nameof(key), key);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<AppSettingsResponse>();
        }

        public async Task<IResult<List<AppSettingsResponse>>> GetAppSettingsAsync(string? query = null)
        {
            var uri = EndPoints.AppSettingController.GetAppSettings;

            if (!string.IsNullOrWhiteSpace(query))
                uri = QueryHelpers.AddQueryString(uri, nameof(query), query);

            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<List<AppSettingsResponse>>();
        }

        public async Task<IResult<string>> AddAppSettingsAsync(AppSettingsRequest request)
        {
            var uri = EndPoints.AppSettingController.AddAppSetting;

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }

        public async Task<IResult> UpdateAppSettingsByIdAsync(string appSettingId, JsonPatchDocument<AppSettingsRequest> request)
        {

            if (string.IsNullOrWhiteSpace(appSettingId))
                return await Result<bool>.FailAsync("AppSettingId is null or empty.");

            var uri = string.Format(EndPoints.AppSettingController.UpdateAppSettingById, appSettingId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult();
        }


    }
}
