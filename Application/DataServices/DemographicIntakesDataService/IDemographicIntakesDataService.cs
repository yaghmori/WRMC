using Microsoft.AspNetCore.JsonPatch;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{
    public interface IDemographicIntakesDataService
    {
        Task<IResult<string>> AddNewDemographicIntakeAsync(DemographicIntakeRequest request);
        Task<IResult<string>> CreateNewDemographicIntakeAsync(IntakeBaseRequest request);
        Task<IResult<bool>> DeleteDemographicIntakeAsync(string demographicIntakeId);
        Task<IResult<DemographicIntakeResponse>> GetDemographicIntakeByIdAsync(string demographicIntakeId);
        Task<IResult<DemographicIntakeResponse>> GetDemographicIntakeByTaskIdAsync(string taskId);
        Task<IResult<List<DemographicIntakeResponse>>> GetDemographicIntakesAsync();
        Task<IResult<bool>> UpdateDemographicIntakeAsync(string demographicIntakeId, JsonPatchDocument<DemographicIntakeRequest> request);
    }
}