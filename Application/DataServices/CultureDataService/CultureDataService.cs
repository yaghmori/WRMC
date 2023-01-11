using Newtonsoft.Json;
using System.Text;
using WRMC.Core.Shared.Extensions;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Core.Shared.Constants;

namespace WRMC.Core.Application.DataServices
{


    public class CultureDataService : DataServiceBase, ICultureDataService
    {
        public CultureDataService(IHttpClientFactory httpClient) : base(httpClient)
        {
        }

        public async Task<IResult<List<CultureResponse>>> GetCulturesAsync()
        {
            string uri = EndPoints.CultureController.GetCultures;
            List<CultureResponse> returnValue = new List<CultureResponse>();
            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<List<CultureResponse>>();

        }

        public async Task<IResult<CultureResponse>> GetCultureByIdAsync(string cultureId)
        {
            if (string.IsNullOrWhiteSpace(cultureId))
                return await Result<CultureResponse>.FailAsync("CultureId is null or empty.");

            string uri = string.Format(EndPoints.CultureController.GetCultureById, cultureId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<CultureResponse>();
        }

        public async Task<IResult<string>> AddCultureAsync(CultureRequest request)
        {
            string uri = EndPoints.CultureController.AddCulture;

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }

        public async Task<IResult<bool>> DeleteCultureByIdAsync(string cultureId)
        {
            if (string.IsNullOrWhiteSpace(cultureId))
                return await Result<bool>.FailAsync("CultureId is null or empty.");

            string uri = string.Format(EndPoints.CultureController.DeleteCultureById, cultureId);


            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> UpdateCultureAsync(string cultureId, CultureRequest request)
        {
            if (string.IsNullOrWhiteSpace(cultureId))
                return await Result<bool>.FailAsync("CultureId is null or empty.");

            string uri = string.Format(EndPoints.CultureController.UpdateCultureById, cultureId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult<bool>();
        }
    }
}
