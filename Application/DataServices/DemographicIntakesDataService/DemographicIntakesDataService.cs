using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Text;
using WRMC.Core.Application.Extensions;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{


    public class DemographicIntakesDataService : DataServiceBase, IDemographicIntakesDataService
    {

        public DemographicIntakesDataService(IHttpClientFactory httpClient) : base(httpClient)
        {

        }

        public async Task<IResult<string>> AddNewDemographicIntakeAsync(DemographicIntakeRequest request)
        {

            var uri = EndPoints.DemographicIntakesController.AddDemographicIntake;

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }
        public async Task<IResult<string>> CreateNewDemographicIntakeAsync(IntakeBaseRequest request)
        {

            var uri = EndPoints.DemographicIntakesController.CreateDemographicIntake;

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }

        public async Task<IResult<List<DemographicIntakeResponse>>> GetDemographicIntakesAsync()
        {
            var uri = EndPoints.DemographicIntakesController.GetDemographicIntakes;
            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<List<DemographicIntakeResponse>>();
        }

        public async Task<IResult<DemographicIntakeResponse>> GetDemographicIntakeByIdAsync(string demographicIntakeId)
        {
            if (string.IsNullOrWhiteSpace(demographicIntakeId))
                return await Result<DemographicIntakeResponse>.FailAsync("Invalid resquest id.");

            var uri = string.Format(EndPoints.DemographicIntakesController.GetDemographicIntakeById, demographicIntakeId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<DemographicIntakeResponse>();
        }

        public async Task<IResult<DemographicIntakeResponse>> GetDemographicIntakeByTaskIdAsync(string taskId)
        {
            if (string.IsNullOrWhiteSpace(taskId))
                return await Result<DemographicIntakeResponse>.FailAsync("Invalid TaskId.");

            var uri = string.Format(EndPoints.DemographicIntakesController.GetDemographicIntakeByTaskId, taskId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<DemographicIntakeResponse>();
        }



        public async Task<IResult<bool>> UpdateDemographicIntakeAsync(string demographicIntakeId, JsonPatchDocument<DemographicIntakeRequest> request)
        {

            if (string.IsNullOrWhiteSpace(demographicIntakeId))
                return await Result<bool>.FailAsync("Invalid resquest id.");

            var uri = string.Format(EndPoints.DemographicIntakesController.UpdateDemographicIntakeById, demographicIntakeId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> DeleteDemographicIntakeAsync(string demographicIntakeId)
        {
            if (string.IsNullOrWhiteSpace(demographicIntakeId))
                return await Result<bool>.FailAsync("Invalid resquest id.");

            var uri = string.Format(EndPoints.DemographicIntakesController.DeleteDemographicIntakeById, demographicIntakeId);
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }


    }

}
