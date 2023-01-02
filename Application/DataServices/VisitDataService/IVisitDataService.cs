using Microsoft.AspNetCore.JsonPatch;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Application.DataServices
{
    public interface IVisitDataService
    {
        Task<IResult<string>> AddDemographicIntakeAsync(string visitId, DemographicIntakeRequest request);
        Task<IResult<string>> AddMedicalInfoAsync(string visitId, MedicalIntakeRequest request);
        Task<IResult<string>> AddTasksAsync(string visitId, string sectionId);
        Task<IResult<string>> CreateNewVisitAsync(VisitRequest request);
        Task<IResult<bool>> DeleteDemographicIntakeAsync(string visitId);
        Task<IResult<bool>> DeleteMedicalInfoAsync(string visitId);
        Task<IResult<bool>> DeleteVisitByIdAsync(string visitId);
        Task<IResult<bool>> DeleteTasksAsync(string taskId);

        Task<IResult<List<DemographicIntakeResponse>>> GetDemographicIntakeAsync(string visitId);
        Task<IResult<List<MedicalIntakeResponse>>> GetMedicalInfoAsync(string visitId);
        Task<IResult<VisitResponse>> GetVisitByIdAsync(string visitId);
        Task<IResult<VisitResponse>> GetVisitByTaskIdAsync(string taskId);
        Task<IResult<UserResponse>> GetUserByTaskIdAsync(string taskId);
        Task<IResult<List<VisitResponse>>> GetVisitsAsync(string? query = null);
        Task<IResult<UserResponse>> GetUserByVisitIdAsync(string visitId);
        Task<IResult<TaskResponse>> GetTaskByIdAsync(string taskId);
        Task<IResult<List<TaskResponse>>> GetTasksAsync(string visitId);
        Task<IResult<bool>> UpdateVisitByIdAsync(string visitId, JsonPatchDocument<VisitRequest> request);
        Task<IResult<bool>> UpdateTaskAsync(string taskId, JsonPatchDocument<TaskRequest> request);
    }
}