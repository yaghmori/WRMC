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
    [Route("api/v1/tenants/intro-methods")]
    [ApiController]
    public class IntroMethodController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IntroMethodController(IUnitOfWork unitOfWork, IMapper mapper)
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
            
                var introMethod = _mapper.Map<IntroMethod>(request);
                var item = await _unitOfWork.IntroMethods.AddAsync(introMethod);
                await _unitOfWork.ServerDbContext.SaveChangesAsync();

                return Ok(await Result<string>.SuccessAsync(data: item.Entity.Id.ToString(), message: "IntroMethod successfully created."));
           
        }


        /// <summary>
        /// Get List of IntroMethods
        /// </summary>
        /// <returns>List of IntroMethodResponse</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<IntroMethodResponse>))]
        public async Task<IActionResult> GetIntroMethods()
        {
           
                var introMethods = await _unitOfWork.IntroMethods.GetAllAsync(
                    predicate: x => x.ParentId.Equals(null),
                    include: i => i.Include(x => x.IntroMethods).ThenInclude(x=>x.IntroMethods).ThenInclude(x=>x.IntroMethods)
                    .Include(x => x.Parent).ThenInclude(x => x.Parent).ThenInclude(x => x.Parent),
                    orderBy:o=>o.OrderBy(x=>x.Order));

                var response = _mapper.Map<List<IntroMethodResponse>>(introMethods);

                return Ok(await Result<List<IntroMethodResponse>>.SuccessAsync(response));
           
        }


        /// <summary>
        /// Get IntroMethod by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IntroMethodResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IntroMethodResponse))]
        public async Task<IActionResult> GetIntroMethodById(string id)
        {
           
                if (string.IsNullOrWhiteSpace(id))
                    return BadRequest(await Result.FailAsync("Invalid request id."));

                var introMethod = await _unitOfWork.IntroMethods.GetFirstOrDefaultAsync(
                    predicate: x => x.Id.ToString().Equals(id),
                    include: i => i.Include(x => x.IntroMethods).ThenInclude(x => x.IntroMethods).ThenInclude(x => x.IntroMethods)
                    .Include(x => x.Parent).ThenInclude(x => x.Parent).ThenInclude(x => x.Parent),
                    orderBy: o => o.OrderBy(x => x.Order));

                var response = _mapper.Map<IntroMethodResponse>(introMethod);
                
                return Ok(await Result<IntroMethodResponse>.SuccessAsync(response));
           
        }


        /// <summary>
        /// Get Parent
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IntroMethodResponse</returns>
        [HttpGet("{id}/parent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IntroMethodResponse))]
        public async Task<IActionResult> GetParent(string id)
        {
           
                if (string.IsNullOrWhiteSpace(id))
                    return BadRequest(await Result.FailAsync("Invalid request id."));

            var introMethod = await _unitOfWork.IntroMethods.FindAsync(Guid.Parse(id));
            if (introMethod == null)
                return NotFound(await Result.FailAsync("IntroMethod Not Found."));

            var parent = await _unitOfWork.IntroMethods.GetFirstOrDefaultAsync(
                    predicate: x => x.Id == introMethod.ParentId);
                var response = _mapper.Map<IntroMethodResponse>(parent);

                return Ok(await Result<IntroMethodResponse>.SuccessAsync(response));
           

        }


        /// <summary>
        /// Update IntroMethod
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateIntroMethod(string id, [FromBody] JsonPatchDocument<IntroMethodRequest> request)
        {
              if (string.IsNullOrWhiteSpace(id))
                    return BadRequest(await Result.FailAsync("Invalid request id."));

                var introMethod = await _unitOfWork.IntroMethods.FindAsync(Guid.Parse(id));
                if (introMethod is null)
                    return NotFound(await Result.FailAsync("IntroMethod not found."));

                var requestToPatch = _mapper.Map<IntroMethodRequest>(introMethod);
                request.ApplyTo(requestToPatch);
                _mapper.Map(requestToPatch, introMethod);

                 _unitOfWork.IntroMethods.Update(introMethod);
                await _unitOfWork.TenantDbContext.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "IntroMethod successfully updated."));
           

        }


        /// <summary>
        /// Delete IntroMethod
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteIntroMethod(string id)
        {
           
                if (string.IsNullOrWhiteSpace(id))
                    return BadRequest(await Result.FailAsync("Invalid request id."));

                var introMethod = await _unitOfWork.IntroMethods.FindAsync(Guid.Parse(id));
                if (introMethod is null)
                    return NotFound(await Result.FailAsync("IntroMethod not found."));

                _unitOfWork.IntroMethods.Remove(introMethod);
                await _unitOfWork.TenantDbContext.SaveChangesAsync();

                return Ok(await Result<bool>.SuccessAsync(true, "IntroMethod successfully deleted."));
           
        }


        /// <summary>
        /// Delete All IntroMethods
        /// </summary>
        /// <returns>bool</returns>
        [HttpDelete("Reset")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteAll()
        {
            
                _unitOfWork.IntroMethods.RemoveAll();
                await _unitOfWork.TenantDbContext.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "All IntroMethods successfully have been deleted."));
            
        }





    }
}
