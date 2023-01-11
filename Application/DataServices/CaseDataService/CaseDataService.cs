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


    public class CaseDataService : DataServiceBase, ICaseDataService
    {

        public CaseDataService(IHttpClientFactory httpClient) : base(httpClient)
        {
        }

        #region Cases
        public async Task<IResult<string>> CreateNewCaseAsync(CaseRequest request)
        {
            var uri = EndPoints.CaseController.CreateNewCase;
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }


        public async Task<IResult<List<CaseResponse>>> GetCasesAsync(string? query = null)
        {
            var uri = EndPoints.CaseController.GetCases;
            if (!string.IsNullOrWhiteSpace(query))
                uri = QueryHelpers.AddQueryString(uri, nameof(query), query);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<List<CaseResponse>>();
        }

        public async Task<IResult<CaseResponse>> GetCaseByIdAsync(string caseId)
        {
            if (string.IsNullOrWhiteSpace(caseId))
                return await Result<CaseResponse>.FailAsync("Invalid RequestId.");


            var uri = string.Format(EndPoints.CaseController.GetCaseById, caseId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<CaseResponse>();
        }

        public async Task<IResult<bool>> UpdateCaseByIdAsync(string caseId, JsonPatchDocument<CaseRequest> request)
        {

            if (string.IsNullOrWhiteSpace(caseId))
                return await Result<bool>.FailAsync("Invalid RequestId.");

            var uri = string.Format(EndPoints.CaseController.UpdateCaseById, caseId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> DeleteCaseByIdAsync(string caseId)
        {
            if (string.IsNullOrWhiteSpace(caseId))
                return await Result<bool>.FailAsync("Invalid RequestId.");

            var uri = string.Format(EndPoints.CaseController.DeleteCaseById, caseId);
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }
        #endregion 

    }
}
