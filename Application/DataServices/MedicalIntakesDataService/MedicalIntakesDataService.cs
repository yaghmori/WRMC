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
    

    public class MedicalIntakesDataService : DataServiceBase, IMedicalIntakesDataService
    {

        public MedicalIntakesDataService(IHttpClientFactory httpClient) : base(httpClient)
        {

        }

        public async Task<IResult<string>> AddNewMedicalIntakeAsync(MedicalIntakeRequest request)
        {

            var uri = EndPoints.MedicalIntakesController.AddMedicalIntake;

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }
        public async Task<IResult<string>> CreateNewMedicalIntakeAsync(IntakeRequest request)
        {

            var uri = EndPoints.MedicalIntakesController.CreateMedicalIntake;

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }

        public async Task<IResult<List<MedicalIntakeResponse>>> GetMedicalIntakesAsync()
        {
            var uri = EndPoints.MedicalIntakesController.GetMedicalIntakes;
            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<List<MedicalIntakeResponse>>();
        }

        public async Task<IResult<MedicalIntakeResponse>> GetMedicalIntakeByIdAsync(string medicalIntakeId)
        {
            if (string.IsNullOrWhiteSpace(medicalIntakeId))
                return await Result<MedicalIntakeResponse>.FailAsync("Invalid resquest id.");

            var uri = string.Format(EndPoints.MedicalIntakesController.GetMedicalIntakeById, medicalIntakeId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<MedicalIntakeResponse>();
        }

        public async Task<IResult<MedicalIntakeResponse>> GetMedicalIntakeByTaskIdAsync(string taskId)
        {
            if (string.IsNullOrWhiteSpace(taskId))
                return await Result<MedicalIntakeResponse>.FailAsync("Invalid TaskId.");

            var uri = string.Format(EndPoints.MedicalIntakesController.GetMedicalIntakeByTaskId, taskId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<MedicalIntakeResponse>();
        }



        public async Task<IResult<bool>> UpdateMedicalIntakeAsync(string medicalIntakeId, JsonPatchDocument<MedicalIntakeRequest> request)
        {

            if (string.IsNullOrWhiteSpace(medicalIntakeId))
                return await Result<bool>.FailAsync("Invalid resquest id.");

            var uri = string.Format(EndPoints.MedicalIntakesController.UpdateMedicalIntakeById, medicalIntakeId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> DeleteMedicalIntakeAsync(string medicalIntakeId)
        {
            if (string.IsNullOrWhiteSpace(medicalIntakeId))
                return await Result<bool>.FailAsync("Invalid resquest id.");

            var uri = string.Format(EndPoints.MedicalIntakesController.DeleteMedicalIntakeById, medicalIntakeId);
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }


    }

}
