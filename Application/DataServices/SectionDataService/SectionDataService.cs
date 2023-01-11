using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.Extensions;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{

    public class SectionDataService : DataServiceBase, ISectionDataService
    {

        public SectionDataService(IHttpClientFactory httpClient) : base(httpClient)
        {

        }

        public async Task<IResult<string>> CreateNewSectionAsync(SectionRequest request)
        {
            var uri = EndPoints.SectionController.CreateNewSection;

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }

        public async Task<IResult<List<SectionResponse>>> GetSectionsAsync(string? query = null)
        {
            var uri = EndPoints.SectionController.GetSections;

            if (!string.IsNullOrWhiteSpace(query))
                uri = QueryHelpers.AddQueryString(uri, nameof(query), query);

            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<List<SectionResponse>>();
        }

        public async Task<IResult<SectionResponse>> GetSectionAsync(string sectionId)
        {
            if (string.IsNullOrWhiteSpace(sectionId))
                return await Result<SectionResponse>.FailAsync("SectionId is null or empty.");


            var uri = string.Format(EndPoints.SectionController.GetSectionById, sectionId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<SectionResponse>();
        }

        public async Task<IResult<SectionResponse>> GetParentSectionAsync(string sectionId)
        {
            if (string.IsNullOrWhiteSpace(sectionId))
                return await Result<SectionResponse>.FailAsync("SectionId is null or empty.");


            var uri = string.Format(EndPoints.SectionController.GetParentSection, sectionId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<SectionResponse>();
        }

        public async Task<IResult<bool>> UpdateSectionAsync(string sectionId, JsonPatchDocument<SectionRequest> request)
        {

            if (string.IsNullOrWhiteSpace(sectionId))
                return await Result<bool>.FailAsync("SectionId is null or empty.");

            var uri = string.Format(EndPoints.SectionController.UpdateSectionById, sectionId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> DeleteSectionAsync(string sectionId)
        {
            if (string.IsNullOrWhiteSpace(sectionId))
                return await Result<bool>.FailAsync("SectionId is null or empty.");

            var uri = string.Format(EndPoints.SectionController.DeleteSectionById, sectionId);
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> DeleteAllSections()
        {
            var uri = EndPoints.SectionController.DeleteAllSections;
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

    }

}
