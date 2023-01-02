using Microsoft.AspNetCore.JsonPatch;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Application.DataServices
{
    public interface ICaseDataService
    {
        Task<IResult<string>> CreateNewCaseAsync(CaseRequest request);
        Task<IResult<bool>> DeleteCaseByIdAsync(string caseId);
        Task<IResult<CaseResponse>> GetCaseByIdAsync(string caseId);
        Task<IResult<List<CaseResponse>>> GetCasesAsync(string? query = null);
        Task<IResult<bool>> UpdateCaseByIdAsync(string caseId, JsonPatchDocument<CaseRequest> request);
    }
}