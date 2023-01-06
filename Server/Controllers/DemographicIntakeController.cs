using AutoMapper;
using Azure;
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
using static MudBlazor.CategoryTypes;

namespace WRMC.Server.Controllers
{
    [Route("api/v1/tenants/intakes/demographics")]
    [ApiController]
    public class DemographicIntakeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DemographicIntakeController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Get All DemographicIntakes
        /// </summary>
        /// <returns>List of DemographicIntakeResponse</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DemographicIntakeResponse>))]
        public async Task<IActionResult> GetDemographicIntakes()
        {
            //TODO : PagedResult
            var results = await _unitOfWork.DemographicIntakes.GetAllAsync(
                include: i => i.Include(x => x.Visit).ThenInclude(x => x.Case));
            var responses = new List<DemographicIntakeResponse>();

            //TODO : Resolve Code Redundancy
            //MultiTenancy
            foreach (var item in results)
            {
                var response = _mapper.Map<DemographicIntakeResponse>(item);

                var userId = item?.Visit?.Case?.UserId;
                var userProfile = await _unitOfWork.UserProfiles.GetFirstOrDefaultAsync(predicate: x => x.UserId.ToString().Equals(userId));

                var regionId = item?.RegionId;
               var region = await _unitOfWork.Regions.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(regionId),
                    include: i => i.Include(x => x.Parent));

                response.Region = _mapper.Map<RegionResponse>(region);
                response.Gender = userProfile?.Gender;
                responses.Add(response);
            }

            return Ok(await Result<List<DemographicIntakeResponse>>.SuccessAsync(responses));

        }

        /// <summary>
        /// Get DemographicIntake by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DemographicIntakeResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DemographicIntakeResponse))]
        public async Task<IActionResult> GetDemographicIntakeById(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var result = await _unitOfWork.DemographicIntakes.GetFirstOrDefaultAsync(
                predicate: x => x.Id.ToString().Equals(id),
               include: i => i.Include(x => x.Visit).ThenInclude(x => x.Case));

            //TODO : Resolve Code Redundancy
            //MultiTenancy          
            var response = _mapper.Map<DemographicIntakeResponse>(result);
            if (result != null)
            {

                var userId = result.Visit?.Case?.UserId;
                var userProfile = await _unitOfWork.UserProfiles.GetFirstOrDefaultAsync(predicate: x => x.UserId.ToString().Equals(userId));

                var regionId = result.RegionId;
                var region = await _unitOfWork.Regions.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(regionId),
                     include: i => i.Include(x => x.Parent));

                response.Region = _mapper.Map<RegionResponse>(region);
                response.Gender = userProfile?.Gender;

                response.Gender = userProfile.Gender;
            }
            return Ok(await Result<DemographicIntakeResponse>.SuccessAsync(response));

        }


        /// <summary>
        /// Get DemographicIntake by taskId
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>DemographicIntakeResponse</returns>
        [HttpGet("Tasks/{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DemographicIntakeResponse))]
        public async Task<IActionResult> GetDemographicIntakeByTaskId(string taskId)
        {

            if (string.IsNullOrWhiteSpace(taskId))
                return BadRequest(await Result.FailAsync("Invalid TaskId."));

            var result = await _unitOfWork.DemographicIntakes.GetFirstOrDefaultAsync(
                predicate: x => x.TaskId.ToString().Equals(taskId),
               include: i => i.Include(x => x.Visit).ThenInclude(x => x.Case));

            //TODO : Resolve Code Redundancy
            //MultiTenancy
            var response = _mapper.Map<DemographicIntakeResponse>(result);
            if (result != null)
            {

                var userId = result.Visit?.Case?.UserId;
                var userProfile = await _unitOfWork.UserProfiles.GetFirstOrDefaultAsync(predicate: x => x.UserId.ToString().Equals(userId));

                var regionId = result.RegionId;
                var region = await _unitOfWork.Regions.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(regionId),
                     include: i => i.Include(x => x.Parent));

                response.Region = _mapper.Map<RegionResponse>(region);
                response.Gender = userProfile?.Gender;

                response.Gender = userProfile.Gender;
            }

            return Ok(await Result<DemographicIntakeResponse>.SuccessAsync(response));

        }

        /// <summary>
        /// Create new DemographicIntake
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="visitId"></param>
        /// <returns>string</returns>
        [HttpPost("new")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> CreateNewDemographicIntake([FromBody] IntakeRequest request)
        {


            //TODO : Check for duplicate
            if (await _unitOfWork.DemographicIntakes.AnyAsync(x => x.VisitId.ToString().Equals(request.VisitId)))
                return Conflict(await Result.FailAsync("The Demograohic Intake already taken."));

            var visit = await _unitOfWork.Visits.FindAsync(Guid.Parse(request.VisitId));
            if (visit is null)
                return NotFound(await Result.FailAsync("Visit not found."));

            var task = await _unitOfWork.Tasks.FindAsync(Guid.Parse(request.TaskId));
            if (task is null)
                return NotFound(await Result.FailAsync("Task not found."));


            var demographicIntake = await _unitOfWork.DemographicIntakes.AddAsync(new DemographicIntake
            {
                VisitId = visit.Id,
                TaskId = task.Id,
                IsComplete = request.IsComplete,
            });

            await _unitOfWork.TenantDbContext.SaveChangesAsync();
            return Ok(await Result<string>.SuccessAsync(data: demographicIntake.Entity.Id.ToString(), message: "Demographic Intake successfully created."));

        }


        /// <summary>
        /// Add new DemographicIntake
        /// </summary>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddDemographicIntake([FromBody] DemographicIntakeRequest request)
        {


            //TODO : Check for duplicate
            if (await _unitOfWork.DemographicIntakes.AnyAsync(x => x.VisitId.ToString().Equals(request.VisitId)))
                return Conflict(await Result.FailAsync("The Demograohic Intake already taken."));

            var visit = await _unitOfWork.Visits.FindAsync(Guid.Parse(request.VisitId));
            if (visit is null)
                return NotFound(await Result.FailAsync("Visit not found."));

            var demographicIntake = _mapper.Map<DemographicIntake>(request);

            //for entity tracker
            demographicIntake.Visit = null;

            await _unitOfWork.DemographicIntakes.AddAsync(demographicIntake);
            await _unitOfWork.TenantDbContext.SaveChangesAsync();
            return Ok(await Result<string>.SuccessAsync(data: demographicIntake.Id.ToString(), message: "Demographic Intake successfully created."));

        }

        /// <summary>
        /// delete DemographicIntake by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>OK</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDemographicIntakeById(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("RequestId is null or empty."));

            var demographicIntake = await _unitOfWork.DemographicIntakes.FindAsync(Guid.Parse(id));
            if (demographicIntake is null)
                return NotFound(await Result.FailAsync("Demographic Intake not found."));

            _unitOfWork.DemographicIntakes.Remove(demographicIntake);
            await _unitOfWork.TenantDbContext.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, "Demographic Intake successfully deleted."));

        }

        /// <summary>
        /// Update DemographicIntake
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>OK</returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateDemographicIntakeById(string id, [FromBody] JsonPatchDocument<DemographicIntakeRequest> request)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var demographicIntake = await _unitOfWork.DemographicIntakes.FindAsync(Guid.Parse(id));
            if (demographicIntake is null)
                return NotFound(await Result.FailAsync("Demographic Intake not found."));

            var demographicIntakeRequest = _mapper.Map<DemographicIntakeRequest>(demographicIntake);
            request.ApplyTo(demographicIntakeRequest);
            _mapper.Map(demographicIntakeRequest, demographicIntake);

            _unitOfWork.DemographicIntakes.Update(demographicIntake);
            await _unitOfWork.TenantDbContext.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, "Demographic Intake successfully updated."));

        }








    }
}
