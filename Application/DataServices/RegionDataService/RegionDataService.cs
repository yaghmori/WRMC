using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using WRMC.Core.Application.Extensions;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WRMC.Core.Application.DataServices
{


    public class RegionDataService : DataServiceBase, IRegionDataService
    {

        public RegionDataService(IHttpClientFactory httpClient) : base(httpClient)
        {

        }

        public async Task<IResult<string>> AddNewRegionAsync(RegionRequest request)
        {
            var uri = EndPoints.RegionController.AddNewRegion;

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }

        public async Task<IResult<List<RegionResponse>>> GetRegionsAsync(string? parentId = null, string? query = null)
        {
            var uri = EndPoints.RegionController.GetRegions;
            if (!string.IsNullOrWhiteSpace(parentId))
                uri = QueryHelpers.AddQueryString(uri, nameof(parentId), parentId);

            if (!string.IsNullOrWhiteSpace(query))
                uri = QueryHelpers.AddQueryString(uri, nameof(query), query);

            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<List<RegionResponse>>();
        }
        public async Task<IResult<List<RegionResponse>>> SearchRegionsAsync(string? query = null)
        {
            var uri = EndPoints.RegionController.SearchRegions;

            if (!string.IsNullOrWhiteSpace(query))
                uri = QueryHelpers.AddQueryString(uri, nameof(query), query);

            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<List<RegionResponse>>();
        }

        public async Task<IResult<RegionResponse>> GetRegionAsync(string regionId)
        {
            if (string.IsNullOrWhiteSpace(regionId))
                return await Result<RegionResponse>.FailAsync("RegionId is null or empty.");


            var uri = string.Format(EndPoints.RegionController.GetRegion, regionId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<RegionResponse>();
        }

        public async Task<IResult<RegionResponse>> GetParentAsync(string regionId)
        {
            if (string.IsNullOrWhiteSpace(regionId))
                return await Result<RegionResponse>.FailAsync("RegionId is null or empty.");


            var uri = string.Format(EndPoints.RegionController.GetParentRegion, regionId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<RegionResponse>();
        }

        public async Task<IResult<bool>> UpdateRegionAsync(string regionId, JsonPatchDocument<RegionRequest> request)
        {

            if (string.IsNullOrWhiteSpace(regionId))
                return await Result<bool>.FailAsync("RegionId is null or empty.");

            var uri = string.Format(EndPoints.RegionController.UpdateRegion, regionId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> DeleteRegionAsync(string regionId)
        {
            if (string.IsNullOrWhiteSpace(regionId))
                return await Result<bool>.FailAsync("RegionId is null or empty.");

            var uri = string.Format(EndPoints.RegionController.DeleteRegion, regionId);
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }


        public async Task<IResult<bool>> DeleteAllRegions()
        {
            var uri = EndPoints.RegionController.DeleteAllRegions;
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

    }

}

