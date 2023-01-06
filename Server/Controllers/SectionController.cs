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
            await _unitOfWork.TenantDbContext.SaveChangesAsync();

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
            await _unitOfWork.TenantDbContext.SaveChangesAsync();

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
            await _unitOfWork.TenantDbContext.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, "Section successfully deleted."));

        }


        /// <summary>
        /// Get Section Claims
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of SectionClaimResponse</returns>
        [HttpGet("{id}/claims")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SectionClaimResponse>))]
        public async Task<IActionResult> GetSectionClaims(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var section = await _unitOfWork.Sections.FindAsync(Guid.Parse(id));
            if (section is null)
                return NotFound(await Result.FailAsync("Section Not Found."));


            var claims = await _unitOfWork.SectionClaims.GetAllAsync(
                predicate: x => x.SectionId == section.Id);
            var response = _mapper.Map<List<SectionClaimResponse>>(claims);

            return Ok(await Result<IList<SectionClaimResponse>>.SuccessAsync(response));

        }


        /// <summary>
        /// Add Section Claim
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        [HttpPost("{id}/claims")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddSectionClaim(string id, SectionClaimRequest request)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var section = await _unitOfWork.Sections.FindAsync(Guid.Parse(id));
            if (section is null)
                return NotFound(await Result.FailAsync("Section Not Found."));

            var sectionClaim = new SectionClaim
            {
                SectionId = section.Id,
                ClaimType = request.ClaimType,
                ClaimValue = request.ClaimValue,
            };

            await _unitOfWork.SectionClaims.AddAsync(sectionClaim);
            await _unitOfWork.TenantDbContext.SaveChangesAsync();

            return Ok(await Result<string>.SuccessAsync(data: sectionClaim.Id.ToString(), message: "Claim successfully added to section."));
        }


        /// <summary>
        /// Update Section Claims
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpPut("{id}/claims")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateSectionClaims(string id, List<SectionClaimRequest> request)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var section = await _unitOfWork.Sections.FindAsync(Guid.Parse(id));
            if (section is null)
                return NotFound(await Result.FailAsync("Section Not Found."));

            _unitOfWork.SectionClaims.RemoveRange(predicate: x => x.SectionId.ToString().Equals(id));
            foreach (var item in request)
            {
                if (item is not null)
                    await _unitOfWork.SectionClaims.AddAsync(new SectionClaim { SectionId = section.Id, ClaimType = item.ClaimType, ClaimValue = item.ClaimType });
            }
            await _unitOfWork.TenantDbContext.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, "SectionClaims successfully updated."));

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
            await _unitOfWork.TenantDbContext.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, "All sections successfully have been deleted."));

        }





    }
}
