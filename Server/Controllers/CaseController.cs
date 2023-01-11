using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.DataAccess.Extensions;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;
using WRMC.Infrastructure.UnitOfWork;
using WRMC.Server.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WRMC.Server.Controllers
{
    [Route("api/v1/server/cases")]
    [ApiController]

    public class CaseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CaseController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        #region Visits


        /// <summary>
        /// Create New Case
        /// </summary>
        /// <param name="request"></param>
        /// <returns>newly created case id as string</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> CreateNewCase(CaseRequest request)
        {
            
                var caseEntity = _mapper.Map<Case>(request);
                await _unitOfWork.Cases.AddAsync(caseEntity);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<string>.SuccessAsync(data: caseEntity.Id.ToString(), "Case successfully Created."));
           
        }


        /// <summary>
        /// Update Case
        /// </summary>
        /// <param name="caseId"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{caseId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateCaseById(string caseId, [FromBody] JsonPatchDocument<CaseRequest> request)
        {
           
                if (string.IsNullOrWhiteSpace(caseId))
                    return BadRequest(await Result.FailAsync("Invalid RequestId."));

                var _case = await _unitOfWork.Cases.FindAsync(Guid.Parse(caseId));
                if (_case is null)
                    return NotFound(await Result.FailAsync("Case not found."));

                var requestToPatch = _mapper.Map<CaseRequest>(_case);
                request.ApplyTo(requestToPatch);
                _mapper.Map(requestToPatch, _case);

                _unitOfWork.Cases.Update(_case);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "Case successfully updated."));
           
        }


        /// <summary>
        /// Get All Cases
        /// </summary>
        /// <returns>List of CaseResponse</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CaseResponse>))]
        public async Task<IActionResult> GetCases(string? query = null)
        {
            
                var cases = await _unitOfWork.Cases.GetAllAsync(
                    predicate: x => (string.IsNullOrWhiteSpace(query) || x.Description.Contains(query)),
                    include:i=>i.Include(x=>x.Visits).ThenInclude(x=>x.Tasks).ThenInclude(x=>x.Section));


                var response = _mapper.Map<List<CaseResponse>>(cases);
                return Ok(await Result<List<CaseResponse>>.SuccessAsync(response));
            
        }


        /// <summary>
        /// Get Case By Id
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns>VisitResponse</returns>
        [HttpGet("{caseId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CaseResponse))]
        public async Task<IActionResult> GetCaseById(string caseId)
        {
           
                if (string.IsNullOrWhiteSpace(caseId))
                    return BadRequest(await Result.FailAsync("Invalid RequestId."));

                var _case = await _unitOfWork.Cases.GetFirstOrDefaultAsync(
                    predicate: x => x.Id.ToString().Equals(caseId));


                if (_case == null)
                    return NotFound(await Result.FailAsync("Case not found."));

                var response = _mapper.Map<CaseResponse>(_case);

                return Ok(await Result<CaseResponse>.SuccessAsync(response));
        
        }


        /// <summary>
        /// Delete Case
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns>bool</returns>
        [HttpDelete("{visitId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteCaseById(string caseId)
        {
                if (string.IsNullOrWhiteSpace(caseId))
                    return BadRequest(await Result.FailAsync("Invalid RequestId."));

                var _case = await _unitOfWork.Cases.FindAsync(Guid.Parse(caseId));
                if (_case is null)
                    return NotFound(await Result.FailAsync("Case not found."));

                _unitOfWork.Cases.Remove(_case);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "Case successfully deleted."));

        }

        #endregion



    }
}
