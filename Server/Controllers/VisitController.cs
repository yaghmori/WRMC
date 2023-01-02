using System.Collections.Immutable;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
using static System.Collections.Specialized.BitVector32;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WRMC.Server.Controllers
{
    [Route("api/v1/server/visits")]
    [ApiController]

    public class VisitController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ServerDbContext> _unitOfWork;

        public VisitController(IMapper mapper, IUnitOfWork<ServerDbContext> unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        #region Visits


        /// <summary>
        /// Create New Visit
        /// </summary>
        /// <param name="request"></param>
        /// <returns>newly created visit id as string</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> CreateNewVisit(VisitRequest request)
        {
            try
            {
                var visit = _mapper.Map<Visit>(request);
                await _unitOfWork.Visits.AddAsync(visit);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<string>.SuccessAsync(data: visit.Id.ToString(), "Visit successfully Created."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }




        /// <summary>
        /// Get All Visits
        /// </summary>
        /// <returns>List of VisitResponse</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<VisitResponse>))]
        public async Task<IActionResult> GetVisits(string? query = null)
        {
            try
            {
                var visits = await _unitOfWork.Visits.GetAllAsync(
                    predicate: x => (!string.IsNullOrWhiteSpace(query) ? x.Comment.Contains(query) : true),
                    include: i => i.Include(x => x.Tasks).ThenInclude(x => x.Section));


                var response = _mapper.Map<List<VisitResponse>>(visits);
                //var response = _mapper.Map<List<VisitResponse>>(visits);
                return Ok(await Result<List<VisitResponse>>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get Visit By Id
        /// </summary>
        /// <param name="visitId"></param>
        /// <returns>VisitResponse</returns>
        [HttpGet("{visitId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VisitResponse))]
        public async Task<IActionResult> GetVisitById(string visitId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(visitId))
                    return BadRequest(await Result.FailAsync("VisitId is null or empty."));

                var visit = await _unitOfWork.Visits.GetFirstOrDefaultAsync(
                     predicate: x => x.Id.ToString().Equals(visitId),
                    include: i => i.Include(x => x.Tasks).ThenInclude(x => x.Section).ThenInclude(x => x.Sections).Include(x => x.Case));

                var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(visit.Case.UserId),
                    include: i => i.Include(x => x.UserProfile));

                if (visit == null)
                    return NotFound(await Result.FailAsync("Visit not found."));

                if (user == null)
                    return NotFound(await Result.FailAsync("user not found."));

                var response = _mapper.Map<VisitResponse>(visit);
                response.Case.User = _mapper.Map<UserResponse>(user);

                return Ok(await Result<VisitResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get User By VisitId
        /// </summary>
        /// <param name="visitId"></param>
        /// <returns>UserResponse</returns>
        [HttpGet("{visitId}/user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VisitResponse))]
        public async Task<IActionResult> GetUserByVisitId(string visitId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(visitId))
                    return BadRequest(await Result.FailAsync("Invalid RequestId."));

                var visit = await _unitOfWork.DbContext.Visits.FirstOrDefaultAsync(x => x.Id.ToString().Equals(visitId));
                var userId = visit?.Case?.UserId;
                var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(userId),
                    include: i => i.Include(x => x.UserProfile).Include(x => x.UserSetting)
                );
                var response = _mapper.Map<UserResponse>(user);

                return Ok(await Result<UserResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Delete Visit
        /// </summary>
        /// <param name="visitId"></param>
        /// <returns>bool</returns>
        [HttpDelete("{visitId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteVisitById(string visitId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(visitId))
                    return BadRequest(await Result.FailAsync("VisitId is null or empty."));

                var visit = await _unitOfWork.Visits.FindAsync(Guid.Parse(visitId));
                if (visit is null)
                    return NotFound(await Result.FailAsync("Visit not found."));

                _unitOfWork.Visits.Remove(visit);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true, "Visit successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Update Visit
        /// </summary>
        /// <param name="visitId"></param>
        /// <returns>bool</returns>
        [HttpPatch("{visitId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateVisit(string visitId, [FromBody] JsonPatchDocument<VisitRequest> request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(visitId))
                    return BadRequest(await Result.FailAsync("Invalid Request Id."));

                var visit = await _unitOfWork.Visits.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(visitId));
                if (visit is null)
                    return NotFound(await Result.FailAsync("Visit not found."));

                var requestToPatch = _mapper.Map<VisitRequest>(visit);
                request.ApplyTo(requestToPatch);
                _mapper.Map(requestToPatch, visit);
                _unitOfWork.Visits.Update(visit);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<bool>.SuccessAsync(true, "Visit successfully updated."));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        #endregion

        #region Tasks

        /// <summary>
        /// Get Tasks
        /// </summary>
        /// <param name="visitId"></param>
        /// <returns>List of TaskResponse</returns>
        [HttpGet("{visitId}/Tasks")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<TaskResponse>))]
        public async Task<IActionResult> GetTasks(string visitId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(visitId))
                    return BadRequest(await Result.FailAsync("VisitId is null or empty."));

                var visit = await _unitOfWork.Visits.FindAsync(Guid.Parse(visitId));

                if (visit == null)
                    return NotFound(await Result.FailAsync("Visit not found."));

                var sections = await _unitOfWork.Tasks.GetAllAsync(
                    predicate: x => x.VisitId.ToString().Equals(visitId),
                    include: i => i.Include(x => x.Section).ThenInclude(x => x.Sections).ThenInclude(x => x.Sections)
                    .Include(x=>x.Section).ThenInclude(x=>x.Parent));

                var response = _mapper.Map<List<TaskResponse>>(sections);

                return Ok(await Result<IList<TaskResponse>>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get Visit By TaskId
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>VisitResponse</returns>
        [HttpGet("Tasks/{taskId}/Visit")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VisitResponse))]
        public async Task<IActionResult> GetVisitByTaskId(string taskId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(taskId))
                    return BadRequest(await Result.FailAsync("Invalid RequestId."));

                var task = await _unitOfWork.Tasks.FindAsync(Guid.Parse(taskId));

                if (task == null)
                    return NotFound(await Result.FailAsync("Task not found."));
                var id = task.VisitId;
                var visit = await _unitOfWork.Visits.GetFirstOrDefaultAsync(
                     predicate: x => x.Id.Equals(task.VisitId),
                    include: i => i.Include(x => x.Tasks).ThenInclude(x => x.Section).ThenInclude(x => x.Sections).Include(x => x.Case));

                //TODO : Change dbContext
                var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(visit.Case.UserId),
                    include: i => i.Include(x => x.UserProfile));

                if (visit == null)
                    return NotFound(await Result.FailAsync("Visit not found."));

                if (user == null)
                    return NotFound(await Result.FailAsync("user not found."));

                var response = _mapper.Map<VisitResponse>(visit);
                response.Case.User= _mapper.Map<UserResponse>(user);
                response.User = _mapper.Map<UserResponse>(user);


                return Ok(await Result<VisitResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Get User By SectionId
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>UserResponse</returns>
        [HttpGet("Tasks/{taskId}/User")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        public async Task<IActionResult> GetUserBySectionId(string taskId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(taskId))
                    return BadRequest(await Result.FailAsync("Invalid RequestId."));



                var task = await _unitOfWork.DbContext.Tasks.FirstOrDefaultAsync(x => x.Id.ToString().Equals(taskId));
                var userId = task?.Visit?.Case?.UserId;
                var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(userId),
                    include: i => i.Include(x => x.UserProfile).Include(x => x.UserSetting)
                );
                var response = _mapper.Map<UserResponse>(user);

                return Ok(await Result<UserResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get Task by Id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>List of TaskResponse</returns>
        [HttpGet("Tasks/{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskResponse))]
        public async Task<IActionResult> GetTaskById(string taskId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(taskId))
                    return BadRequest(await Result.FailAsync("Invalid RequestId."));

                var task = await _unitOfWork.Tasks.FindAsync(Guid.Parse(taskId));

                if (task == null)
                    return NotFound(await Result.FailAsync("Task not found."));

                var response = _mapper.Map<TaskResponse>(task);

                return Ok(await Result<TaskResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Add Task
        /// </summary>
        /// <param name="visitId"></param>
        /// <param name="sectionId"></param>
        /// <returns>string</returns>
        [HttpPost("{visitId}/Tasks/{sectionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddTask(string visitId, string sectionId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(visitId))
                    return BadRequest(await Result.FailAsync("VisitId is null or empty."));

                var visit = await _unitOfWork.Visits.FindAsync(Guid.Parse(visitId));

                if (visit == null)
                    return NotFound(await Result.FailAsync("Visit not found."));

                var section = await _unitOfWork.Sections.FindAsync(Guid.Parse(sectionId));
                if (section == null)
                    return NotFound(await Result.FailAsync("Section not found."));

                //var isDuplicate = await _unitOfWork.Tasks.AnyAsync(x => x.VisitId == visit.Id && x.SectionId == section.Id);
                //if (isDuplicate)
                //    return NotFound(await Result.FailAsync("Current section already created for this visit."));

                var workflows = await _unitOfWork.Sections.GetAllAsync(
                    predicate: x => x.Parent.ParentId == section.Id,
                    include: i => i.Include(x => x.Parent).ThenInclude(x => x.Parent));

                var addedSectionList = new List<string>();
                var firstStepItems = workflows?.Where(x => x.Parent.Order == workflows.Min(m => m.Parent.Order));

                foreach (var workflow in workflows)
                {
                    var task = new Tasks
                    {
                        SectionId = workflow.Id,
                        VisitId = visit.Id,
                        Status = TaskStatusEnum.NotCompleted,
                    };


                    if (firstStepItems.Any(x => x.Id == workflow.Id))
                    {
                        task.Status = TaskStatusEnum.InProgress;
                        task.StartDate = DateTime.UtcNow;
                    }

                    var record = await _unitOfWork.Tasks.AddAsync(task);
                    addedSectionList.Add(record.Entity.Id.ToString());

                    //var firstStep = workflows?.FirstOrDefault(x => x.SectionGroup == SectionGroupEnum.Step && x.Order == workflows.Min(m => m.Order));
                    ////First Step
                    //if (item.Id == firstStep?.Id)
                    //{
                    //    task.Status = TaskStatusEnum.InProgress;
                    //    task.StartDate = DateTime.UtcNow;
                    //}
                    //First workflow(s) of firstStep



                }


                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<List<string>>.SuccessAsync(addedSectionList, $"{addedSectionList.Count} VisitSection(0) successfully added."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Delete Section
        /// </summary>
        /// <param name="visitSectionId"></param>
        /// <returns>string</returns>
        [HttpDelete("VisitSections/{visitSectionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> DeleteVisitSection(string visitSectionId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(visitSectionId))
                    return BadRequest(await Result.FailAsync("VisitSectionId is null or empty."));

                var visitSection = await _unitOfWork.Tasks.FindAsync(Guid.Parse(visitSectionId));
                if (visitSection == null)
                    return NotFound(await Result.FailAsync("VisitSection not found."));

                _unitOfWork.Tasks.Remove(visitSection);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<bool>.SuccessAsync(true, "VisitSection successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Update Section Status
        /// </summary>
        /// <param name="visitId"></param>
        /// <param name="visitSectionId"></param>
        /// <param name="status"></param>
        /// <returns>bool</returns>
        [HttpPatch("VisitSections/{visitSectionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateVisitSection(string visitSectionId, [FromBody] JsonPatchDocument<TaskRequest> request)
        {
            try
            {
                var visitSection = await _unitOfWork.Tasks.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(visitSectionId));
                if (visitSection is null)
                    return NotFound(await Result.FailAsync("visitSection not found."));

                var requestToPatch = _mapper.Map<TaskRequest>(visitSection);
                request.ApplyTo(requestToPatch);
                _mapper.Map(requestToPatch, visitSection);
                _unitOfWork.Tasks.Update(visitSection);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<bool>.SuccessAsync(true, " VisitSection successfully updated."));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        #endregion

        #region MedicalIntakes

        /// <summary>
        /// Add MedicalIntake
        /// </summary>
        /// <param name="visitId"></param>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost("{visitId}/MedicalIntakes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddMedicalIntake(string visitId, MedicalIntakeRequest request)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(visitId))
                    return BadRequest(await Result.FailAsync("Invalid RequestId."));

                var visit = await _unitOfWork.Visits.FindAsync(Guid.Parse(visitId));

                if (visit == null)
                    return NotFound(await Result.FailAsync("Visit not found."));

                if (await _unitOfWork.MedicalIntakes.AnyAsync(a => a.VisitId.Equals(visitId)))
                    return Conflict(await Result.FailAsync("Medical information for this visit is already exist."));

                var medicalInfo = _mapper.Map<MedicalIntake>(request);
                await _unitOfWork.MedicalIntakes.AddAsync(medicalInfo);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<string>.SuccessAsync(data: medicalInfo.Id.ToString(), "Medical information successfully Created."));



            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }

        }


        /// <summary>
        /// Get MedicalIntakes
        /// </summary>
        /// <param name="visitId"></param>
        /// <returns>List of MedicalInfoResponse</returns>
        [HttpGet("{visitId}/MedicalIntakes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MedicalIntakeResponse>))]
        public async Task<IActionResult> GetMedicalIntakes(string visitId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(visitId))
                    return BadRequest(await Result.FailAsync("Invalid RequestId."));

                var visit = await _unitOfWork.Visits.FindAsync(Guid.Parse(visitId));

                if (visit == null)
                    return NotFound(await Result.FailAsync("Visit not found."));

                var medicalInfo = await _unitOfWork.MedicalIntakes.GetAllAsync(
                    predicate: x => x.VisitId.Equals(visitId));

                var response = _mapper.Map<List<MedicalIntakeResponse>>(medicalInfo);

                return Ok(await Result<List<MedicalIntakeResponse>>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Delete MedicalIntake
        /// </summary>
        /// <param name="medicalIntakeId"></param>
        /// <returns>bool</returns>
        [HttpDelete("MedicalIntakes/{medicalIntakeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> DeleteMedicalIntake(string medicalIntakeId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(medicalIntakeId))
                    return BadRequest(await Result.FailAsync("MedicalInfo Id is null or empty."));

                var medicalInfo = await _unitOfWork.MedicalIntakes.FindAsync(Guid.Parse(medicalIntakeId));
                if (medicalInfo == null)
                    return NotFound(await Result.FailAsync("MedicalInfo not found."));

                _unitOfWork.MedicalIntakes.Remove(medicalInfo);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<bool>.SuccessAsync(true, "MedicalInfo successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        #endregion

        #region DemographicIntake

        /// <summary>
        /// Add DemographicIntake
        /// </summary>
        /// <param name="visitId"></param>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPost("{visitId}/DemographicIntake")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddDemographicIntake(string visitId, DemographicIntakeRequest request)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(visitId))
                    return BadRequest(await Result.FailAsync("VisitId is null or empty."));

                var visit = await _unitOfWork.Visits.FindAsync(Guid.Parse(visitId));

                if (visit == null)
                    return NotFound(await Result.FailAsync("Visit not found."));

                if (await _unitOfWork.DemographicIntakes.AnyAsync(a => a.VisitId.Equals(visitId)))
                    return Conflict(await Result.FailAsync("Demographic intake for this visit is already exist."));

                var demographicIntake = _mapper.Map<DemographicIntake>(request);
                await _unitOfWork.DemographicIntakes.AddAsync(demographicIntake);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<string>.SuccessAsync(data: demographicIntake.Id.ToString(), "Demographic intake successfully Created."));



            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }

        }


        /// <summary>
        /// Get Demographic Intake
        /// </summary>
        /// <param name="visitId"></param>
        /// <returns>List of DemographicIntakeResponse</returns>
        [HttpGet("{visitId}/DemographicIntake")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DemographicIntakeResponse>))]
        public async Task<IActionResult> GetDemographicIntake(string visitId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(visitId))
                    return BadRequest(await Result.FailAsync("VisitId is null or empty."));

                var visit = await _unitOfWork.Visits.FindAsync(Guid.Parse(visitId));

                if (visit == null)
                    return NotFound(await Result.FailAsync("Visit not found."));

                var demographicIntakes = await _unitOfWork.DemographicIntakes.GetAllAsync(
                    predicate: x => x.VisitId.Equals(visitId));

                var response = _mapper.Map<List<DemographicIntakeResponse>>(demographicIntakes);

                return Ok(await Result<List<DemographicIntakeResponse>>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Delete DemographicIntake
        /// </summary>
        /// <param name="demographicIntakeId"></param>
        /// <returns>bool</returns>
        [HttpDelete("DemographicIntake/{demographicIntakeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> DeleteDemographicIntake(string demographicIntakeId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(demographicIntakeId))
                    return BadRequest(await Result.FailAsync("Demographic Intake Id is null or empty."));

                var demographicIntake = await _unitOfWork.DemographicIntakes.FindAsync(Guid.Parse(demographicIntakeId));
                if (demographicIntake == null)
                    return NotFound(await Result.FailAsync("Demographic Intake not found."));

                _unitOfWork.DemographicIntakes.Remove(demographicIntake);
                await _unitOfWork.SaveChangesAsync();

                return Ok(await Result<bool>.SuccessAsync(true, "Demographic Intake successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        #endregion


    }
}
