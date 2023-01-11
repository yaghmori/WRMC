using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.DataAccess.Extensions;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork;
using WRMC.Server.Extensions;

namespace WRMC.Server.Controllers
{
    [Route("api/v1/tenants/sections")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SectionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Create New Section.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> CreateNewSection(SectionRequest request)
        {

            var section = _mapper.Map<Section>(request);
            var item = await _unitOfWork.Sections.AddAsync(section);
            await _unitOfWork.SaveChangesAsync();

            return Ok(await Result<string>.SuccessAsync(data: item.Entity.Id.ToString(), message: "Section successfully created."));

        }


        /// <summary>
        /// Get List of Section
        /// </summary>
        /// <returns>List of SectionResponse</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SectionResponse>))]
        public async Task<IActionResult> GetSections()
        {

            var sections = await _unitOfWork.Sections.GetAllAsync(
                predicate: x => x.ParentId == null,
                include: i => i.Include(x => x.Sections).ThenInclude(x => x.Sections));

            var response = _mapper.Map<List<SectionResponse>>(sections);

            return Ok(await Result<List<SectionResponse>>.SuccessAsync(response));

        }


        /// <summary>
        /// Get Section by Id
        /// </summary>
        /// <returns>SectionResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SectionResponse))]
        public async Task<IActionResult> GetSectionById(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var section = await _unitOfWork.Sections.GetFirstOrDefaultAsync(
                predicate: x => x.Id.ToString().Equals(id),
                include: i => i.Include(x => x.Sections).ThenInclude(x => x.Sections));

            var response = _mapper.Map<SectionResponse>(section);

            return Ok(await Result<SectionResponse>.SuccessAsync(response));

        }


        /// <summary>
        /// Get Parent Section
        /// </summary>
        /// <param name="id"></param>
        /// <returns>SectionResponse</returns>
        [HttpGet("{id}/parent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SectionResponse))]
        public async Task<IActionResult> GetParentSection(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var section = await _unitOfWork.Sections.FindAsync(Guid.Parse(id));
            if (section == null)
                return NotFound(await Result.FailAsync("Section Not Found."));

            var parent = await _unitOfWork.Sections.GetFirstOrDefaultAsync(
                predicate: x => x.Id == section.ParentId);
            var response = _mapper.Map<SectionResponse>(parent);

            return Ok(await Result<SectionResponse>.SuccessAsync(response));
        }


        /// <summary>
        /// Update Section
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateSection(string id, [FromBody] JsonPatchDocument<SectionRequest> request)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var section = await _unitOfWork.Sections.FindAsync(Guid.Parse(id));
            if (section is null)
                return NotFound(await Result.FailAsync("Section not found."));

            var requestToPatch = _mapper.Map<SectionRequest>(section);
            request.ApplyTo(requestToPatch);
            _mapper.Map(requestToPatch, section);

            _unitOfWork.Sections.Update(section);
            await _unitOfWork.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, "Section successfully updated."));
        }


        /// <summary>
        /// Delete Section
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteSection(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var section = await _unitOfWork.Sections.FindAsync(Guid.Parse(id));
            if (section is null)
                return NotFound(await Result.FailAsync("Section not found."));

            _unitOfWork.Sections.Remove(section);
            await _unitOfWork.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, "Section successfully deleted."));

        }



        /// <summary>
        /// Delete All Sections
        /// </summary>
        /// <returns>bool</returns>
        [HttpDelete("Reset")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteAllSections()
        {
            _unitOfWork.Sections.RemoveAll();
            await _unitOfWork.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, "All sections successfully have been deleted."));

        }





    }
}
