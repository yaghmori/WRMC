using Microsoft.AspNetCore.JsonPatch;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{
    public interface IAppSettingDataService
    {
        Task<IResult<List<AppSettingsResponse>>> GetAppSettingsAsync(string? query = null);
        Task<IResult<AppSettingsResponse>> GetAppSettingsByIdAsync(string appSettingId);
        Task<IResult<AppSettingsResponse>> GetAppSettingsByKeyAsync(string key);
        Task<IResult<bool>> DeleteAppSettingsByIdAsync(string appSettingId);
        Task<IResult<bool>> DeleteAppSettingsByKeyAsync(string key);
        Task<IResult<string>> AddAppSettingsAsync(AppSettingsRequest request);
        Task<IResult> UpdateAppSettingsByIdAsync(string appSettingId, JsonPatchDocument<AppSettingsRequest> request);

    }
}