using Microsoft.AspNetCore.JsonPatch;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{
    public interface IUserSettingDataService
    {
        Task<IResult<List<UserSettingResponse>>> GetUserSettingsAsync(string? query = null);
        Task<IResult<UserSettingResponse>> GetUserSettingsByIdAsync(string userSettingId);
        Task<IResult<bool>> DeleteUserSettingsByIdAsync(string userSettingId);
        Task<IResult<string>> AddUserSettingsAsync(UserSettingRequest request);
        Task<IResult> UpdateSettingsAsync(string settingId, JsonPatchDocument<UserSettingRequest> request);
        Task<IResult<UserSettingResponse>> GetUserSettingsByUserIdAsync(string userId);
    }
}