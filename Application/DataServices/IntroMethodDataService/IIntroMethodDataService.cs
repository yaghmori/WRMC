using Microsoft.AspNetCore.JsonPatch;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{
    public interface IIntroMethodDataService
    {
        Task<IResult<string>> CreateNewIntroMethodAsync(IntroMethodRequest request);
        Task<IResult<List<IntroMethodResponse>>> GetIntroMethodsAsync(string? query = null);
        Task<IResult<IntroMethodResponse>> GetIntroMethodAsync(string introMethodId);
        Task<IResult<IntroMethodResponse>> GetParentIntroMethodAsync(string introMethodId);
        Task<IResult<bool>> UpdateIntroMethodAsync(string introMethodId, JsonPatchDocument<IntroMethodRequest> request);
        Task<IResult<bool>> DeleteIntroMethodAsync(string introMethodId);
        Task<IResult<bool>> DeleteAllIntroMethods();
    }
}