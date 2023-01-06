using Microsoft.AspNetCore.JsonPatch;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Application.DataServices
{
    public interface IVisitDataService
    {
        Task<IResult<string>> AddTasksAsync(string visitId, string sectionId);
        Task<IResult<string>> CreateNewVisitAsync(VisitRequest request);
        Task<IResult<bool>> DeleteTasksAsync(string taskId);
        Task<IResult<bool>> DeleteVisitByIdAsync(string visitId);
        Task<IResult<TaskResponse>> GetTaskByIdAsync(string taskId);
        Task<IResult<List<TaskResponse>>> GetTasksAsync(string visitId);
        Task<IResult<UserResponse>> GetUserByTaskIdAsync(string visitSectionId);
        Task<IResult<UserResponse>> GetUserByVisitIdAsync(string visitId);
        Task<IResult<VisitResponse>> GetVisitByIdAsync(string visitId);
        Task<IResult<VisitResponse>> GetVisitByTaskIdAsync(string visitSectionId);
        Task<IResult<List<VisitResponse>>> GetVisitsAsync(string? query = null);
        Task<IResult<IPagedList<VisitResponse>>> GetVisitsPagedAsync(int page = 0, int pageSize = 10, string query = null);
        Task<IResult<bool>> UpdateTaskAsync(string taskId, JsonPatchDocument<TaskRequest> request);
        Task<IResult<bool>> UpdateVisitByIdAsync(string visitId, JsonPatchDocument<VisitRequest> request);
    }
}