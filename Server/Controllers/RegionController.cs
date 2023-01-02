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

namespace WRMC.Server.Controllers
{
    [Route("api/v1/server/Regions")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IUnitOfWork<ServerDbContext> _unitOfWork;
        private readonly IMapper _mapper;

        public RegionController(IUnitOfWork<ServerDbContext> unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add New Region.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddNewRegion(RegionRequest request)
        {
            try
            {
                var region = _mapper.Map<Region>(request);
                var item = await _unitOfWork.Regions.AddAsync(region);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<string>.SuccessAsync(data: item.Entity.Id.ToString(), message: "Region successfully added."));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        /// <summary>
        /// Get Regions
        /// </summary>
        /// <returns>List of RegionResponse</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RegionResponse>))]
        public async Task<IActionResult> GetRegions(string? parentId =null,string? query =null)
        {
            try
            {
                var sections = await _unitOfWork.Regions.GetAllAsync(
                    predicate: x => x.ParentId.ToString().Equals(parentId) && ( string.IsNullOrWhiteSpace(query) || x.Name.ToLower().Contains(query)),
                    include:i=>i.Include(x=>x.Parent));

                var response = _mapper.Map<List<RegionResponse>>(sections);

                return Ok(await Result<List<RegionResponse>>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Search Regions
        /// </summary>
        /// <returns>List of RegionResponse</returns>
        [HttpGet("Search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RegionResponse>))]
        public async Task<IActionResult> SearchRegions(string query = null)
        {
            try
            {

                var regions =await _unitOfWork.DbContext.Regions
                    .Where(x => x.RegionType == RegionTypeEnum.City && x.Name.ToLower().Contains(query))
                    .Select(x => x.Parent).Distinct()
                    .GroupBy(d => d.Parent).Select(group => new RegionResponse
                    {
                        Id = group.Key.Id.ToString(),
                        ParentId = group.Key.Id.ToString(),
                        RegionType = group.Key.RegionType,
                        Name = group.Key.Name,
                        OfficialName = group.Key.OfficialName,
                        Iso3 = group.Key.Iso3,
                        Iso2 =group.Key.Iso2,
                        Regions = group.Select(s => new RegionResponse
                        {
                            Id = s.Id.ToString(),
                            ParentId = s.ParentId.ToString(),
                            RegionType = s.RegionType,
                            Name = s.Name,
                            OfficialName = s.OfficialName,
                            Iso3 = s.Iso3,
                            Iso2 = s.Iso2,
                            Regions = s.Regions.Where(x => x.RegionType == RegionTypeEnum.City && x.Name.ToLower().Contains(query)).Select(c => new RegionResponse
                            {
                                Id = c.Id.ToString(),
                                ParentId = c.ParentId.ToString(),
                                RegionType = c.RegionType,
                                Name = c.Name,
                                OfficialName = c.OfficialName,
                                Iso3 = c.Iso3,
                                Iso2 = c.Iso2,
                            }).ToList()
                        }).ToList()
                    }).ToListAsync();
                //var response = _mapper.Map<List<RegionResponse>>(regions);

                return Ok(await Result<List<RegionResponse>>.SuccessAsync(regions));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }



        /// <summary>
        /// Get Region by Id
        /// </summary>
        /// <returns>RegionResponse</returns>
        [HttpGet("{regionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegionResponse))]
        public async Task<IActionResult> GetRegionById(string regionId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(regionId))
                    return BadRequest(await Result.FailAsync("Invalid request id."));

                var section = await _unitOfWork.Regions.GetFirstOrDefaultAsync(
                    predicate: x => x.Id.ToString().Equals(regionId),
                    include: i => i.Include(x => x.Regions).ThenInclude(x => x.Regions));

                var response = _mapper.Map<RegionResponse>(section);

                return Ok(await Result<RegionResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get Parent Region
        /// </summary>
        /// <param name="regionId"></param>
        /// <returns>RegionResponse</returns>
        [HttpGet("{regionId}/parent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegionResponse))]
        public async Task<IActionResult> GetParentRegion(string regionId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(regionId))
                    return BadRequest(await Result.FailAsync("Invalid request id."));

                var section = await _unitOfWork.Regions.FindAsync(Guid.Parse(regionId));
                if (section == null)
                    return NotFound(await Result.FailAsync("Region not found."));

                var parent = await _unitOfWork.Regions.GetFirstOrDefaultAsync(
                    predicate: x => x.Id == section.ParentId);
                var response = _mapper.Map<RegionResponse>(parent);

                return Ok(await Result<RegionResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }

        }


        /// <summary>
        /// Update Region
        /// </summary>
        /// <param name="regionId"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{regionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateRegion(string regionId, [FromBody] JsonPatchDocument<RegionRequest> request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(regionId))
                    return BadRequest(await Result.FailAsync("Invalid request id."));

                var region = await _unitOfWork.Regions.FindAsync(Guid.Parse(regionId));
                if (region is null)
                    return NotFound(await Result.FailAsync("Region not found."));

                var requestToPatch = _mapper.Map<RegionRequest>(region);
                request.ApplyTo(requestToPatch);
                _mapper.Map(requestToPatch, region);

                _unitOfWork.Regions.Update(region);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "Region successfully updated."));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }

        }


        /// <summary>
        /// Delete Region
        /// </summary>
        /// <param name="regionId"></param>
        /// <returns>bool</returns>
        [HttpDelete("{regionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteRegion(string regionId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(regionId))
                    return BadRequest(await Result.FailAsync("Invalid request id."));

                var region = await _unitOfWork.Regions.FindAsync(Guid.Parse(regionId));
                if (region is null)
                    return NotFound(await Result.FailAsync("Region not found."));

                _unitOfWork.Regions.Remove(region);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<bool>.SuccessAsync(true, "Region successfully deleted."));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }




        /// <summary>
        /// Delete All Regions
        /// </summary>
        /// <returns>bool</returns>
        [HttpDelete("Reset")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteAllRegions()
        {
            try
            {
                _unitOfWork.Regions.RemoveAll();
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "All regions successfully have been deleted."));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }





    }
}
