using Microsoft.AspNetCore.JsonPatch;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{
    public interface IRegionDataService
    {
        Task<IResult<string>> AddNewRegionAsync(RegionRequest request);
        Task<IResult<bool>> DeleteAllRegions();
        Task<IResult<bool>> DeleteRegionAsync(string regionId);
        Task<IResult<RegionResponse>> GetParentAsync(string regionId);
        Task<IResult<RegionResponse>> GetRegionAsync(string regionId);
        Task<IResult<List<RegionResponse>>> GetRegionsAsync(string? parentId = null, string? query = null);
        Task<IResult<List<RegionResponse>>> SearchRegionsAsync(string? query = null);
        Task<IResult<bool>> UpdateRegionAsync(string regionId, JsonPatchDocument<RegionRequest> request);
    }
}