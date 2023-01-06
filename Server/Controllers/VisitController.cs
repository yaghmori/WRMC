using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;
using WRMC.Infrastructure.UnitOfWork;
using WRMC.Server.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WRMC.Server.Controllers
{
    [Route("api/v1/tenants/visits")]
    [ApiController]

    public class VisitController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VisitController(IMapper mapper, IUnitOfWork unitOfWork)
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

            var visit = _mapper.Map<Visit>(request);
            await _unitOfWork.Visits.AddAsync(visit);
            await _unitOfWork.TenantDbContext.SaveChangesAsync();
            return Ok(await Result<string>.SuccessAsync(data: visit.Id.ToString(), "Visit successfully Created."));

        }




        /// <summary>
        /// Get All Visits
        /// </summary>
        /// <returns>List of VisitResponse</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<VisitResponse>))]
        public async Task<IActionResult> GetVisits(string? query = null, int page = 0, int pageSize = 10, bool paged = true)
        {
            //TODO : Paged Result
            if (paged)
            {
                var visits = await _unitOfWork.Visits.GetPagedListAsync(
                    predicate: x => (!string.IsNullOrWhiteSpace(query) ? x.Comment.Contains(query) : true),
                    include: i => i.Include(x => x.Tasks).ThenInclude(x => x.Section),
                    orderBy: o => o.OrderByDescending(k => k.StartDate),
                    pageIndex: Convert.ToInt32(page),
                    pageSize: Convert.ToInt32(pageSize) > 100 ? 100 : Convert.ToInt32(pageSize));

                var response = _mapper.Map<PagedList<VisitResponse>>(visits);
                foreach (var visit in visits.Items)
                {
                    var userId = visit?.Case?.UserId;
                    var user = _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(userId),
                        include: i => i.Include(x => x.UserSetting).Include(x => x.UserProfile));

                    //mapp user
                    var visitResponse = response.Items.Where(x => x.Id.Equals(visit.Id.ToString())).FirstOrDefault();
                    if (visitResponse != null)
                    {
                        visitResponse.Case.User = _mapper.Map<UserResponse>(user);
                        visitResponse.User = _mapper.Map<UserResponse>(user);

                    }
                }

                return Ok(await Result<IPagedList<VisitResponse>>.SuccessAsync(response));

            }
            else
            {
                var visits = await _unitOfWork.Visits.GetAllAsync(
                   predicate: x => (!string.IsNullOrWhiteSpace(query) ? x.Comment.Contains(query) : true),
                   include: i => i.Include(x => x.Tasks).ThenInclude(x => x.Section));

                var response = _mapper.Map<List<VisitResponse>>(visits);

                //Disable for performance issues 
                #region include user
                //foreach (var visit in visits)
                //{
                //    var userId = visit?.Case?.UserId;
                //    var user = _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(userId),
                //        include: i => i.Include(x => x.UserSetting).Include(x => x.UserProfile));

                //    //mapp user
                //    var visitResponse = response.Where(x => x.Id.Equals(visit.Id.ToString())).FirstOrDefault();
                //    if (visitResponse != null)
                //    {
                //        visitResponse.Case.User = _mapper.Map<UserResponse>(user);
                //        visitResponse.User = _mapper.Map<UserResponse>(user);

                //    }
                //}
                #endregion

                return Ok(await Result<List<VisitResponse>>.SuccessAsync(response));
            }

        }


        /// <summary>
        /// Get Visit By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>VisitResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VisitResponse))]
        public async Task<IActionResult> GetVisitById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("VisitId is null or empty."));

            var visit = await _unitOfWork.Visits.GetFirstOrDefaultAsync(
                 predicate: x => x.Id.ToString().Equals(id),
                include: i => i.Include(x => x.Tasks).ThenInclude(x => x.Section).ThenInclude(x => x.Sections).Include(x => x.Case));

            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(visit.Case.UserId),
                include: i => i.Include(x => x.UserProfile));

            var response = _mapper.Map<VisitResponse>(visit);

            //mapp user
            if (response != null)
            {
                response.Case.User = _mapper.Map<UserResponse>(user);
                response.User = _mapper.Map<UserResponse>(user);
            }

            return Ok(await Result<VisitResponse>.SuccessAsync(response));

        }


        /// <summary>
        /// Get User By VisitId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>UserResponse</returns>
        [HttpGet("{id}/user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VisitResponse))]
        public async Task<IActionResult> GetUserByVisitId(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid RequestId."));

            var visit = await _unitOfWork.Visits.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(id),
                include: i => i.Include(x => x.Case));
            var userId = visit?.Case?.UserId;
            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(userId),
                include: i => i.Include(x => x.UserProfile).Include(x => x.UserSetting));

            var response = _mapper.Map<UserResponse>(user);

            return Ok(await Result<UserResponse>.SuccessAsync(response));

        }


        /// <summary>
        /// Delete Visit
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteVisitById(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("VisitId is null or empty."));

            var visit = await _unitOfWork.Visits.FindAsync(Guid.Parse(id));
            if (visit is null)
                return NotFound(await Result.FailAsync("Visit not found."));

            _unitOfWork.Visits.Remove(visit);
            await _unitOfWork.ServerDbContext.SaveChangesAsync();
            return Ok(await Result<bool>.SuccessAsync(true, "Visit successfully deleted."));

        }


        /// <summary>
        /// Update Visit
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateVisit(string id, [FromBody] JsonPatchDocument<VisitRequest> request)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid Request Id."));

            var visit = await _unitOfWork.Visits.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(id));
            if (visit is null)
                return NotFound(await Result.FailAsync("Visit not found."));

            var requestToPatch = _mapper.Map<VisitRequest>(visit);
            request.ApplyTo(requestToPatch);
            _mapper.Map(requestToPatch, visit);
            _unitOfWork.Visits.Update(visit);
            await _unitOfWork.ServerDbContext.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, "Visit successfully updated."));

        }

        #endregion

        #region Tasks

        /// <summary>
        /// Get Tasks
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of TaskResponse</returns>
        [HttpGet("{id}/tasks")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<TaskResponse>))]
        public async Task<IActionResult> GetTasks(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("VisitId is null or empty."));

            var visit = await _unitOfWork.Visits.FindAsync(Guid.Parse(id));

            if (visit == null)
                return NotFound(await Result.FailAsync("Visit not found."));

            var sections = await _unitOfWork.Tasks.GetAllAsync(
                predicate: x => x.VisitId.ToString().Equals(id),
                include: i => i.Include(x => x.Section).ThenInclude(x => x.Sections).ThenInclude(x => x.Sections)
                .Include(x => x.Section).ThenInclude(x => x.Parent));

            var response = _mapper.Map<List<TaskResponse>>(sections);

            return Ok(await Result<IList<TaskResponse>>.SuccessAsync(response));

        }


        /// <summary>
        /// Get Visit By TaskId
        /// </summary>
        /// <param name="id">task Id</param>
        /// <returns>VisitResponse</returns>
        [HttpGet("tasks/{id}/visit")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VisitResponse))]
        public async Task<IActionResult> GetVisitByTaskId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var task = await _unitOfWork.Tasks.FindAsync(Guid.Parse(id));
            if (task == null)
                return NotFound(await Result.FailAsync("Task not found."));

            var visit = await _unitOfWork.Visits.GetFirstOrDefaultAsync(
                 predicate: x => x.Id.Equals(task.VisitId),
                include: i => i.Include(x => x.Tasks).ThenInclude(x => x.Section).ThenInclude(x => x.Sections).Include(x => x.Case));

            if (visit == null)
                return NotFound(await Result.FailAsync("Visit not found."));

            //MultiTenancy
            var userId = visit?.Case?.UserId;
            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(userId),
                include: i => i.Include(x => x.UserProfile));

            var response = _mapper.Map<VisitResponse>(visit);

            //mapp user
            if (response != null)
            {
                response.Case.User = _mapper.Map<UserResponse>(user);
                response.User = _mapper.Map<UserResponse>(user);
            }

            return Ok(await Result<VisitResponse>.SuccessAsync(response));

        }

        /// <summary>
        /// Get User By SectionId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>UserResponse</returns>
        [HttpGet("tasks/{id}/user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        public async Task<IActionResult> GetUserBySectionId(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid RequestId."));



            var task = await _unitOfWork.Tasks.GetFirstOrDefaultAsync(predicate : x => x.Id.ToString().Equals(id));
            var userId = task?.Visit?.Case?.UserId;
            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(userId),
                include: i => i.Include(x => x.UserProfile).Include(x => x.UserSetting)
            );
            var response = _mapper.Map<UserResponse>(user);

            return Ok(await Result<UserResponse>.SuccessAsync(response));

        }


        /// <summary>
        /// Get Task by Id
        /// </summary>
        /// <param name="id">TaskId</param>
        /// <returns>List of TaskResponse</returns>
        [HttpGet("tasks/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskResponse))]
        public async Task<IActionResult> GetTaskById(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid RequestId."));

            var task = await _unitOfWork.Tasks.FindAsync(Guid.Parse(id));
            var response = _mapper.Map<TaskResponse>(task);

            return Ok(await Result<TaskResponse>.SuccessAsync(response));

        }


        /// <summary>
        /// Add Task
        /// </summary>
        /// <param name="vid">Visit Id</param>
        /// <param name="sid">Section Id</param>
        /// <returns>string</returns>
        [HttpPost("{vid}/tasks/{sid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddTask(string vid, string sid)
        {

            if (string.IsNullOrWhiteSpace(vid))
                return BadRequest(await Result.FailAsync("VisitId is null or empty."));

            var visit = await _unitOfWork.Visits.FindAsync(Guid.Parse(vid));

            if (visit == null)
                return NotFound(await Result.FailAsync("Visit not found."));

            var section = await _unitOfWork.Sections.FindAsync(Guid.Parse(sid));
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


            await _unitOfWork.TenantDbContext.SaveChangesAsync();

            return Ok(await Result<List<string>>.SuccessAsync(addedSectionList, $"{addedSectionList.Count} VisitSection(0) successfully added."));

        }


        /// <summary>
        /// Delete Section
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        [HttpDelete("visit-sections/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> DeleteVisitSection(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("VisitSectionId is null or empty."));

            var visitSection = await _unitOfWork.Tasks.FindAsync(Guid.Parse(id));
            if (visitSection == null)
                return NotFound(await Result.FailAsync("VisitSection not found."));

            _unitOfWork.Tasks.Remove(visitSection);
            await _unitOfWork.TenantDbContext.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, "VisitSection successfully deleted."));

        }


        /// <summary>
        /// Update Section Status
        /// </summary>
        /// <param name="visitId"></param>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns>bool</returns>
        [HttpPatch("visit-sections/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateVisitSection(string id, [FromBody] JsonPatchDocument<TaskRequest> request)
        {

            var visitSection = await _unitOfWork.Tasks.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(id));
            if (visitSection is null)
                return NotFound(await Result.FailAsync("visitSection not found."));

            var requestToPatch = _mapper.Map<TaskRequest>(visitSection);
            request.ApplyTo(requestToPatch);
            _mapper.Map(requestToPatch, visitSection);
            _unitOfWork.Tasks.Update(visitSection);
            await _unitOfWork.TenantDbContext.SaveChangesAsync();

            return Ok(await Result<bool>.SuccessAsync(true, " VisitSection successfully updated."));

        }

        #endregion


    }
}
