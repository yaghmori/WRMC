using Microsoft.AspNetCore.JsonPatch;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{
    public interface IMedicalIntakesDataService
    {
        Task<IResult<string>> AddNewMedicalIntakeAsync(MedicalIntakeRequest request);
        Task<IResult<string>> CreateNewMedicalIntakeAsync(IntakeRequest request);
        Task<IResult<bool>> DeleteMedicalIntakeAsync(string medicalIntakeId);
        Task<IResult<MedicalIntakeResponse>> GetMedicalIntakeByIdAsync(string medicalIntakeId);
        Task<IResult<MedicalIntakeResponse>> GetMedicalIntakeByTaskIdAsync(string taskId);
        Task<IResult<List<MedicalIntakeResponse>>> GetMedicalIntakesAsync();
        Task<IResult<bool>> UpdateMedicalIntakeAsync(string medicalIntakeId, JsonPatchDocument<MedicalIntakeRequest> request);
    }
}