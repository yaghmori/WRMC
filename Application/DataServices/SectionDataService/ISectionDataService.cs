using Microsoft.AspNetCore.JsonPatch;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{
    public interface ISectionDataService
    {
        Task<IResult<string>> CreateNewSectionAsync(SectionRequest request);
        Task<IResult<List<SectionResponse>>> GetSectionsAsync(string? query = null);
        Task<IResult<SectionResponse>> GetSectionAsync(string sectionId);
        Task<IResult<SectionResponse>> GetParentSectionAsync(string sectionId);
        Task<IResult<bool>> UpdateSectionAsync(string sectionId, JsonPatchDocument<SectionRequest> request);
        Task<IResult<bool>> DeleteSectionAsync(string sectionId);
        Task<IResult<bool>> DeleteAllSections();
    }
}