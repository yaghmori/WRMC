using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using WRMC.Core.Application.Extensions;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{


    public class UserSettingDataService : DataServiceBase, IUserSettingDataService
    {

        public UserSettingDataService(IHttpClientFactory httpClient) : base(httpClient)
        {
        }



        public async Task<IResult<bool>> DeleteUserSettingsByIdAsync(string usersettingId)
        {

            if (string.IsNullOrWhiteSpace(usersettingId))
                return await Result<bool>.FailAsync("UsersettingId is null or empty.");

            var uri = string.Format(EndPoints.UserSettingController.DeleteUserSettingById, usersettingId);

            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<UserSettingResponse>> GetUserSettingsByIdAsync(string usersettingId)
        {
            if (string.IsNullOrWhiteSpace(usersettingId))
                return await Result<UserSettingResponse>.FailAsync("UsersettingId is null or empty.");


            var uri = string.Format(EndPoints.UserSettingController.GetUserSettingById, usersettingId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<UserSettingResponse>();
        }

        public async Task<IResult<List<UserSettingResponse>>> GetUserSettingsAsync(string? query = null)
        {
            var uri = EndPoints.UserSettingController.GetUserSettings;

            if (!string.IsNullOrWhiteSpace(query))
                uri = QueryHelpers.AddQueryString(uri, nameof(query), query);

            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<List<UserSettingResponse>>();
        }

        public async Task<IResult<UserSettingResponse>> GetUserSettingsByUserIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<UserSettingResponse>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserSettingController.GetUserSettingByUserId,userId);
            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<UserSettingResponse>();
        }

        public async Task<IResult<string>> AddUserSettingsAsync(UserSettingRequest request)
        {
            var uri = EndPoints.UserSettingController.AddUserSetting;

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }

        public async Task<IResult> UpdateSettingsAsync(string settingId, JsonPatchDocument<UserSettingRequest> request)
        {
            if (string.IsNullOrWhiteSpace(settingId))
                return await Result<bool>.FailAsync("UserSettingId is null or empty.");

            var uri = string.Format(EndPoints.UserSettingController.UpdateUserSettingById, settingId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult();
        }


    }
}
