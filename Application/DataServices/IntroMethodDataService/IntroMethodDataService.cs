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

    public class IntroMethodDataService : DataServiceBase, IIntroMethodDataService
    {

        public IntroMethodDataService(IHttpClientFactory httpClient) : base(httpClient)
        {

        }

        public async Task<IResult<string>> CreateNewIntroMethodAsync(IntroMethodRequest request)
        {
            var uri = EndPoints.IntroMethodController.CreateNewIntroMethod;

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }

        public async Task<IResult<List<IntroMethodResponse>>> GetIntroMethodsAsync(string? query = null)
        {
            var uri = EndPoints.IntroMethodController.GetIntroMethods;

            if (!string.IsNullOrWhiteSpace(query))
                uri = QueryHelpers.AddQueryString(uri, nameof(query), query);

            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<List<IntroMethodResponse>>();
        }

        public async Task<IResult<IntroMethodResponse>> GetIntroMethodAsync(string introMethodId)
        {
            if (string.IsNullOrWhiteSpace(introMethodId))
                return await Result<IntroMethodResponse>.FailAsync("IntroMethodId is null or empty.");


            var uri = string.Format(EndPoints.IntroMethodController.GetIntroMethodById, introMethodId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<IntroMethodResponse>();
        }

        public async Task<IResult<IntroMethodResponse>> GetParentIntroMethodAsync(string introMethodId)
        {
            if (string.IsNullOrWhiteSpace(introMethodId))
                return await Result<IntroMethodResponse>.FailAsync("IntroMethodId is null or empty.");


            var uri = string.Format(EndPoints.IntroMethodController.GetParentIntroMethod, introMethodId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<IntroMethodResponse>();
        }

        public async Task<IResult<bool>> UpdateIntroMethodAsync(string introMethodId, JsonPatchDocument<IntroMethodRequest> request)
        {

            if (string.IsNullOrWhiteSpace(introMethodId))
                return await Result<bool>.FailAsync("IntroMethodId is null or empty.");

            var uri = string.Format(EndPoints.IntroMethodController.UpdateIntroMethodById, introMethodId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> DeleteIntroMethodAsync(string introMethodId)
        {
            if (string.IsNullOrWhiteSpace(introMethodId))
                return await Result<bool>.FailAsync("IntroMethodId is null or empty.");

            var uri = string.Format(EndPoints.IntroMethodController.DeleteIntroMethodById, introMethodId);
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> DeleteAllIntroMethods()
        {
            var uri = EndPoints.IntroMethodController.DeleteAllIntroMethods;
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

    }

}
