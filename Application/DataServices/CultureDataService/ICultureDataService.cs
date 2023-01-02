using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{
    public interface ICultureDataService
    {
        Task<IResult<string>> AddCultureAsync(CultureRequest request);
        Task<IResult<bool>> DeleteCultureByIdAsync(string cultureId);
        Task<IResult<CultureResponse>> GetCultureByIdAsync(string cultureId);
        Task<IResult<List<CultureResponse>>> GetCulturesAsync();
        Task<IResult<bool>> UpdateCultureAsync(string cultureId, CultureRequest request);
    }
}