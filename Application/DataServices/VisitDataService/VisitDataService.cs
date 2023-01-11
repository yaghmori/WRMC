using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using WRMC.Core.Shared.Extensions;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Infrastructure.Domain.Enums;
using WRMC.Core.Shared.Constants;

namespace WRMC.Core.Application.DataServices
{


    public class VisitDataService : DataServiceBase, IVisitDataService
    {

        public VisitDataService(IHttpClientFactory httpClient) : base(httpClient)
        {
        }

        #region Visits
        public async Task<IResult<string>> CreateNewVisitAsync(VisitRequest request)
        {
            var uri = EndPoints.VisitController.CreateNewVisit;
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }
        public async Task<IResult<List<VisitResponse>>> GetVisitsAsync(string? query = null)
        {
            var uri = EndPoints.VisitController.GetVisits;
            uri = QueryHelpers.AddQueryString(uri, "paged", "false");
            if (!string.IsNullOrWhiteSpace(query))
                uri = QueryHelpers.AddQueryString(uri, nameof(query), query);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<List<VisitResponse>>();
        }
        public async Task<IResult<IPagedList<VisitResponse>>> GetVisitsPagedAsync(int page = 0, int pageSize = 10, string query = null)
        {
            var uri = EndPoints.VisitController.GetVisits;

            uri = QueryHelpers.AddQueryString(uri, "page", page.ToString());
            uri = QueryHelpers.AddQueryString(uri, "pageSize", pageSize.ToString());
            if (!string.IsNullOrWhiteSpace(query))
                uri = QueryHelpers.AddQueryString(uri, nameof(query), query);


            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<PagedList<VisitResponse>>();
        }
        public async Task<IResult<VisitResponse>> GetVisitByIdAsync(string visitId)
        {
            if (string.IsNullOrWhiteSpace(visitId))
                return await Result<VisitResponse>.FailAsync("VisitId is null or empty.");


            var uri = string.Format(EndPoints.VisitController.GetVisitById, visitId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<VisitResponse>();
        }
        public async Task<IResult<UserResponse>> GetUserByVisitIdAsync(string visitId)
        {
            if (string.IsNullOrWhiteSpace(visitId))
                return await Result<UserResponse>.FailAsync("Invalid RequestId.");


            var uri = string.Format(EndPoints.VisitController.GetUserByVisitId, visitId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<UserResponse>();
        }
        public async Task<IResult<VisitResponse>> GetVisitByTaskIdAsync(string visitSectionId)
        {
            if (string.IsNullOrWhiteSpace(visitSectionId))
                return await Result<VisitResponse>.FailAsync("Invalid RequestId.");


            var uri = string.Format(EndPoints.VisitController.GetVisitByTaskId, visitSectionId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<VisitResponse>();
        }
        public async Task<IResult<UserResponse>> GetUserByTaskIdAsync(string visitSectionId)
        {
            if (string.IsNullOrWhiteSpace(visitSectionId))
                return await Result<UserResponse>.FailAsync("Invalid RequestId.");


            var uri = string.Format(EndPoints.VisitController.GetUserByTaskId, visitSectionId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<UserResponse>();
        }
        public async Task<IResult<bool>> UpdateVisitByIdAsync(string visitId, JsonPatchDocument<VisitRequest> request)
        {

            if (string.IsNullOrWhiteSpace(visitId))
                return await Result<bool>.FailAsync("Invalid RequestId.");

            var uri = string.Format(EndPoints.VisitController.UpdateVisitById, visitId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult<bool>();
        }
        public async Task<IResult<bool>> DeleteVisitByIdAsync(string visitId)
        {
            if (string.IsNullOrWhiteSpace(visitId))
                return await Result<bool>.FailAsync("VisitId is null or empty.");

            var uri = string.Format(EndPoints.VisitController.DeleteVisitById, visitId);
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }
        #endregion 

        #region Tasks
        public async Task<IResult<string>> AddTasksAsync(string visitId, string sectionId)
        {
            if (string.IsNullOrWhiteSpace(visitId))
                return await Result<string>.FailAsync("Invalid VisitId.");

            if (string.IsNullOrWhiteSpace(sectionId))
                return await Result<string>.FailAsync("Invalid SectionId.");

            var uri = string.Format(EndPoints.VisitController.AddTask, visitId, sectionId);
            var response = await _httpClient.PostAsync(uri, null);
            return await response.ToResult<string>();
        }
        public async Task<IResult<bool>> DeleteTasksAsync(string taskId)
        {
            if (string.IsNullOrWhiteSpace(taskId))
                return await Result<bool>.FailAsync("Invalid RequestId.");

            var uri = string.Format(EndPoints.VisitController.DeleteTask, taskId);
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }
        public async Task<IResult<List<TaskResponse>>> GetTasksAsync(string visitId)
        {
            if (string.IsNullOrWhiteSpace(visitId))
                return await Result<List<TaskResponse>>.FailAsync("VisitId is null or empty.");

            var uri = string.Format(EndPoints.VisitController.GetTasks, visitId);
            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<List<TaskResponse>>();
        }
        public async Task<IResult<TaskResponse>> GetTaskByIdAsync(string taskId)
        {
            if (string.IsNullOrWhiteSpace(taskId))
                return await Result<TaskResponse>.FailAsync("Invalid RequestId.");

            var uri = string.Format(EndPoints.VisitController.GetTaskById, taskId);
            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<TaskResponse>();
        }
        public async Task<IResult<bool>> UpdateTaskAsync(string taskId, JsonPatchDocument<TaskRequest> request)
        {
            if (string.IsNullOrWhiteSpace(taskId))
                return await Result<bool>.FailAsync("Invalid RequestId.");

            var uri = string.Format(EndPoints.VisitController.UpdateTask, taskId);
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");

            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult<bool>();
        }

        #endregion

    }
}
