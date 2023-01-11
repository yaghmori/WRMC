using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork;
using WRMC.Server.Extensions;

namespace WRMC.Server.Controllers
{
    [Route("api/v1/server/cultures")]
    [ApiController]
    public class CultureController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CultureController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Get All Cultures
        /// </summary>
        /// <returns>List of CultureResponse</returns>
        [HttpGet]
        public async Task<IActionResult> GetCultures()
        {

            var cultures = await _unitOfWork.Cultures.GetAllAsync();
            var response = _mapper.Map<List<CultureResponse>>(cultures);
            return Ok(await Result<List<CultureResponse>>.SuccessAsync(response));

        }

        /// <summary>
        /// Get culture by id
        /// </summary>
        /// <param name="cultureId"></param>
        /// <returns>List of CultureResponse</returns>
        [HttpGet("{cultureId}")]
        public async Task<IActionResult> GetCultureById(string cultureId)
        {
            if (string.IsNullOrWhiteSpace(cultureId))
                return BadRequest(await Result.FailAsync("RequestId is null or empty."));

            var result = await _unitOfWork.Cultures.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(cultureId));
            if (result == null)
                return NotFound(await Result.FailAsync("Culture not found."));
            var response = _mapper.Map<CultureResponse>(result);
            return Ok(await Result<CultureResponse>.SuccessAsync(response));

        }

        /// <summary>
        /// Add new culture
        /// </summary>
        /// <param name="request"></param>
        /// <returns>string(CultureId)</returns>
        [HttpPost]
        public async Task<IActionResult> AddCulture(CultureRequest request)
        {
            if (await _unitOfWork.Cultures.AnyAsync(x => x.CultureName.Equals(request.CultureName)))
                return Conflict(await Result.FailAsync("The culture is already defined."));

            var culture = _mapper.Map<Culture>(request);
            await _unitOfWork.Cultures.AddAsync(culture);
            await _unitOfWork.SaveChangesAsync();
            return Ok(await Result<string>.SuccessAsync(data: culture.Id.ToString(), message: "Culture successfully created."));

        }

        /// <summary>
        /// delete culture by Id
        /// </summary>
        /// <param name="cultureId"></param>
        /// <returns>OK</returns>
        [HttpDelete("{cultureId}")]
        public async Task<IActionResult> DeleteCultureById(string cultureId)
        {
            if (string.IsNullOrWhiteSpace(cultureId))
                return BadRequest(await Result.FailAsync("RequestId is null or empty."));

            var culture = await _unitOfWork.Cultures.FindAsync(Guid.Parse(cultureId));
            if (culture is null)
                return NotFound(await Result.FailAsync("Culture not found."));

            _unitOfWork.Cultures.Remove(culture);
            await _unitOfWork.SaveChangesAsync();
            return Ok(await Result<bool>.SuccessAsync(true, "Culture successfully deleted."));

        }

        /// <summary>
        /// Update culture
        /// </summary>
        /// <param name="cultureId"></param>
        /// <param name="request"></param>
        /// <returns>OK</returns>
        [HttpPatch("{cultureId}")]
        public async Task<IActionResult> UpdateCultureById(string cultureId, CultureRequest request)
        {
            if (string.IsNullOrWhiteSpace(cultureId))
                return BadRequest(await Result.FailAsync("RequestId is null or empty."));

            var culture = await _unitOfWork.Cultures.FindAsync(Guid.Parse(cultureId));
            if (culture is null)
                return NotFound(await Result.FailAsync("Culture not found."));

            culture = _mapper.Map<Culture>(request);
            _unitOfWork.Cultures.Update(culture);
            await _unitOfWork.SaveChangesAsync();
            return Ok(await Result<bool>.SuccessAsync(true, "Culture successfully updated."));

        }

    }
}
