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
    [Route("api/v1/tenants/intakes/medicals")]
    [ApiController]
    public class MedicalIntakeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MedicalIntakeController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Get All MedicalIntakes
        /// </summary>
        /// <returns>List of MedicalIntakeResponse</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MedicalIntakeResponse>))]
        public async Task<IActionResult> GetMedicalIntakes()
        {

            var results = await _unitOfWork.MedicalIntakes.GetAllAsync();
            var response = _mapper.Map<List<MedicalIntakeResponse>>(results);
            return Ok(await Result<List<MedicalIntakeResponse>>.SuccessAsync(response));

        }

        /// <summary>
        /// Get MedicalIntake by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>MedicalIntakeResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicalIntakeResponse))]
        public async Task<IActionResult> GetMedicalIntakeById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var result = await _unitOfWork.MedicalIntakes.GetFirstOrDefaultAsync(
                predicate: x => x.Id.ToString().Equals(id),
               include: i => i.Include(x => x.Visit).ThenInclude(x => x.Case));

            var response = _mapper.Map<MedicalIntakeResponse>(result);
            return Ok(await Result<MedicalIntakeResponse>.SuccessAsync(response));
        }


        /// <summary>
        /// Get MedicalIntake by taskId
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>MedicalIntakeResponse</returns>
        [HttpGet("Tasks/{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicalIntakeResponse))]
        public async Task<IActionResult> GetMedicalIntakeByTaskId(string taskId)
        {
            if (string.IsNullOrWhiteSpace(taskId))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var result = await _unitOfWork.MedicalIntakes.GetFirstOrDefaultAsync(
                predicate: x => x.TaskId.ToString().Equals(taskId),
                include: i => i.Include(x => x.Visit).ThenInclude(x => x.Case));

            var response = _mapper.Map<MedicalIntakeResponse>(result);
            return Ok(await Result<MedicalIntakeResponse>.SuccessAsync(response));
        }

        /// <summary>
        /// Create new MedicalIntake
        /// </summary>
        /// <returns>string</returns>
        [HttpPost("new")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> CreateMedicalIntake([FromBody] IntakeBaseRequest request)
        {


            //TODO : Check for duplicate
            if (await _unitOfWork.MedicalIntakes.AnyAsync(x => x.VisitId.ToString().Equals(request.VisitId)))
                return Conflict(await Result.FailAsync("The Demograohic Intake already taken."));

            var visit = await _unitOfWork.Visits.FindAsync(Guid.Parse(request.VisitId));
            if (visit is null)
                return NotFound(await Result.FailAsync("Visit not found."));

            var task = await _unitOfWork.Tasks.FindAsync(Guid.Parse(request.TaskId));
            if (task is null)
                return NotFound(await Result.FailAsync("Task not found."));


            var medicalIntake = await _unitOfWork.MedicalIntakes.AddAsync(new MedicalIntake
            {
                VisitId = visit.Id,
                TaskId = task.Id,
                IsComplete = request.IsComplete,
            });
            await _unitOfWork.SaveChangesAsync();
            return Ok(await Result<string>.SuccessAsync(data: medicalIntake.Entity.Id.ToString(), message: "Medical Intake successfully created."));

        }


        /// <summary>
        /// Add new MedicalIntake
        /// </summary>
        /// <param name="request"></param>
        /// <param name="visitId"></param>
        /// <returns>string</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddMedicalIntake([FromBody] MedicalIntakeRequest request)
        {


            //TODO : Check for duplicate
            if (await _unitOfWork.MedicalIntakes.AnyAsync(x => x.VisitId.ToString().Equals(request.VisitId)))
                return Conflict(await Result.FailAsync("The Demograohic Intake already taken."));

            var visit = await _unitOfWork.Visits.FindAsync(Guid.Parse(request.VisitId));
            if (visit is null)
                return NotFound(await Result.FailAsync("Visit not found."));

            var medicalIntake = _mapper.Map<MedicalIntake>(request);
            await _unitOfWork.MedicalIntakes.AddAsync(medicalIntake);
            await _unitOfWork.SaveChangesAsync();
            return Ok(await Result<string>.SuccessAsync(data: medicalIntake.Id.ToString(), message: "Medical Intake successfully created."));

        }

        /// <summary>
        /// delete MedicalIntake by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>OK</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalIntakeById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var medicalIntake = await _unitOfWork.MedicalIntakes.FindAsync(Guid.Parse(id));
            if (medicalIntake is null)
                return NotFound(await Result.FailAsync("Medical Intake not found."));

            _unitOfWork.MedicalIntakes.Remove(medicalIntake);
            await _unitOfWork.SaveChangesAsync();
            return Ok(await Result<bool>.SuccessAsync(true, "Medical Intake successfully deleted."));
        }

        /// <summary>
        /// Update MedicalIntake
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>OK</returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateMedicalIntakeById(string id, [FromBody] JsonPatchDocument<MedicalIntakeRequest> request)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(await Result.FailAsync("Invalid request id."));

            var medicalIntake = await _unitOfWork.MedicalIntakes.FindAsync(Guid.Parse(id));
            if (medicalIntake is null)
                return NotFound(await Result.FailAsync("Medical Intake not found."));

            var medicalIntakeRequest = _mapper.Map<MedicalIntakeRequest>(medicalIntake);
            request.ApplyTo(medicalIntakeRequest);
            _mapper.Map(medicalIntakeRequest, medicalIntake);

            _unitOfWork.MedicalIntakes.Update(medicalIntake);
            await _unitOfWork.SaveChangesAsync();
            return Ok(await Result<bool>.SuccessAsync(true, "Medical Intake successfully updated."));
        }

    }
}
