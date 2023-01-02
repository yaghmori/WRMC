using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork;
using WRMC.Server.Extensions;

namespace WRMC.Server.Controllers
{
    [Route("api/v1/server/IntroMethods")]
    [ApiController]
    public class IntroMethodController : ControllerBase
    {
        private readonly IUnitOfWork<ServerDbContext> _unitOfWork;
        private readonly IMapper _mapper;

        public IntroMethodController(IUnitOfWork<ServerDbContext> unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Create New IntroMethod.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> CreateNewIntroMethod(IntroMethodRequest request)
        {
            try
            {
                var introMethod = _mapper.Map<IntroMethod>(request);
                var item = await _unitOfWork.IntroMethods.AddAsync(introMethod);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<string>.SuccessAsync(data: item.Entity.Id.ToString(), message: "IntroMethod successfully created."));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        /// <summary>
        /// Get List of IntroMethods
        /// </summary>
        /// <returns>List of IntroMethodResponse</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<IntroMethodResponse>))]
        public async Task<IActionResult> GetIntroMethods()
        {
            try
            {
                var introMethods = await _unitOfWork.IntroMethods.GetAllAsync(
                    predicate: x => x.ParentId.Equals(null),
                    include: i => i.Include(x => x.IntroMethods).ThenInclude(x=>x.IntroMethods).ThenInclude(x=>x.IntroMethods)
                    .Include(x => x.Parent).ThenInclude(x => x.Parent).ThenInclude(x => x.Parent),
                    orderBy:o=>o.OrderBy(x=>x.Order));

                var response = _mapper.Map<List<IntroMethodResponse>>(introMethods);

                return Ok(await Result<List<IntroMethodResponse>>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get IntroMethod by Id
        /// </summary>
        /// <returns>IntroMethodResponse</returns>
        [HttpGet("{introMethodId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IntroMethodResponse))]
        public async Task<IActionResult> GetIntroMethodById(string introMethodId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(introMethodId))
                    return BadRequest(await Result.FailAsync("Invalid request id."));

                var introMethod = await _unitOfWork.IntroMethods.GetFirstOrDefaultAsync(
                    predicate: x => x.Id.ToString().Equals(introMethodId),
                    include: i => i.Include(x => x.IntroMethods).ThenInclude(x => x.IntroMethods).ThenInclude(x => x.IntroMethods)
                    .Include(x => x.Parent).ThenInclude(x => x.Parent).ThenInclude(x => x.Parent),
                    orderBy: o => o.OrderBy(x => x.Order));

                var response = _mapper.Map<IntroMethodResponse>(introMethod);
                
                return Ok(await Result<IntroMethodResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get Parent
        /// </summary>
        /// <param name="introMethodId"></param>
        /// <returns>IntroMethodResponse</returns>
        [HttpGet("{introMethodId}/parent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IntroMethodResponse))]
        public async Task<IActionResult> GetParent(string introMethodId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(introMethodId))
                    return BadRequest(await Result.FailAsync("Invalid request id."));

                var introMethod = await _unitOfWork.IntroMethods.FindAsync(Guid.Parse(introMethodId));
                if (introMethod == null)
                    return NotFound(await Result.FailAsync("IntroMethod Not Found."));

                var parent = await _unitOfWork.IntroMethods.GetFirstOrDefaultAsync(
                    predicate: x => x.Id == introMethod.ParentId);
                var response = _mapper.Map<IntroMethodResponse>(parent);

                return Ok(await Result<IntroMethodResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }

        }


        /// <summary>
        /// Update IntroMethod
        /// </summary>
        /// <param name="introMethodId"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{introMethodId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateIntroMethod(string introMethodId, [FromBody] JsonPatchDocument<IntroMethodRequest> request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(introMethodId))
                    return BadRequest(await Result.FailAsync("Invalid request id."));

                var introMethod = await _unitOfWork.IntroMethods.FindAsync(Guid.Parse(introMethodId));
                if (introMethod is null)
                    return NotFound(await Result.FailAsync("IntroMethod not found."));

                var requestToPatch = _mapper.Map<IntroMethodRequest>(introMethod);
                request.ApplyTo(requestToPatch);
                _mapper.Map(requestToPatch, introMethod);

                 _unitOfWork.IntroMethods.Update(introMethod);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "IntroMethod successfully updated."));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }

        }


        /// <summary>
        /// Delete IntroMethod
        /// </summary>
        /// <param name="introMethodId"></param>
        /// <returns>bool</returns>
        [HttpDelete("{introMethodId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteIntroMethod(string introMethodId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(introMethodId))
                    return BadRequest(await Result.FailAsync("Invalid request id."));

                var introMethod = await _unitOfWork.IntroMethods.FindAsync(Guid.Parse(introMethodId));
                if (introMethod is null)
                    return NotFound(await Result.FailAsync("IntroMethod not found."));

                _unitOfWork.IntroMethods.Remove(introMethod);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<bool>.SuccessAsync(true, "IntroMethod successfully deleted."));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Delete All IntroMethods
        /// </summary>
        /// <returns>bool</returns>
        [HttpDelete("Reset")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                _unitOfWork.IntroMethods.RemoveAll();
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "All IntroMethods successfully have been deleted."));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }





    }
}
