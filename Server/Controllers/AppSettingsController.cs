﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork;
using WRMC.Server.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WRMC.Server.Controllers
{
    [Route("api/v1/server/AppSettings")]
    [ApiController]

    public class AppSettingsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ServerDbContext> _unitOfWork;

        public AppSettingsController(IMapper mapper, IUnitOfWork<ServerDbContext> unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }




        /// <summary>
        /// Add new AppSetting 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>AppSettingId as string</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddAppSetting(AppSettingsRequest request)
        {
            try
            {
                if (await _unitOfWork.AppSettings.AnyAsync(x => x.Key.Equals(request.Key)))
                    return Conflict(await Result.FailAsync("key is already defined."));

                var appSetting = _mapper.Map<AppSetting>(request);
                await _unitOfWork.AppSettings.AddAsync(appSetting);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<string>.SuccessAsync(data: appSetting.Id.ToString(),"AppSettings successfully created."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Get All AppSettings
        /// </summary>
        /// <returns>List of AppSettingsResponse</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AppSettingsResponse>))]
        public async Task<IActionResult> GetAppSettings(string? query = null)
        {
            try
            {
                var appSettings = await _unitOfWork.AppSettings.GetAllAsync(
                    predicate: x => (!string.IsNullOrWhiteSpace(query) ? x.Key.Contains(query) : true));
                var response = _mapper.Map<List<AppSettingsResponse>>(appSettings);
                return Ok(await Result<IList<AppSettingsResponse>>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get AppSetting By Id
        /// </summary>
        /// <param name="appSettingsId"></param>
        /// <returns>AppSettingsResponse</returns>
        [HttpGet("{appSettingsId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AppSettingsResponse))]
        public async Task<IActionResult> GetAppSettingsById(string appSettingsId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(appSettingsId))
                    return BadRequest(await Result.FailAsync("AppSettingsId is null or empty."));

                var appSetting = await _unitOfWork.AppSettings.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(appSettingsId));

                if (appSetting == null)
                    return NotFound(await Result.FailAsync("AppSetting not found."));

                var response = _mapper.Map<AppSettingsResponse>(appSetting);
                return Ok(await Result<AppSettingsResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Get AppSetting By Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>AppSettingsResponse</returns>
        [HttpGet("keys")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AppSettingsResponse))]
        public async Task<IActionResult> GetAppSettingsByKey(string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key))
                    return BadRequest(await Result.FailAsync("Key is null or empty."));

                var appSetting = await _unitOfWork.AppSettings.GetFirstOrDefaultAsync(predicate: x => x.Key.Equals(key));

                if (appSetting == null)
                    return NotFound(await Result.FailAsync("AppSetting not found."));

                var response = _mapper.Map<AppSettingsResponse>(appSetting);
                return Ok(await Result<AppSettingsResponse>.SuccessAsync(response));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Delete AppSetting By Id
        /// </summary>
        /// <param name="appSettingsId"></param>
        /// <returns>bool</returns>
        [HttpDelete("{appSettingsId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteAppSettingById(string appSettingsId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(appSettingsId))
                    return BadRequest(await Result.FailAsync("AppSettingsId is null or empty."));

                var appSetting = await _unitOfWork.AppSettings.FindAsync(Guid.Parse(appSettingsId));
                if (appSetting is null)
                    return NotFound(await Result.FailAsync("AppSetting not found."));

                _unitOfWork.AppSettings.Remove(appSetting);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true,"AppSetting successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }


        /// <summary>
        /// Delete AppSetting By Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>bool</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteAppSettingByKey(string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key))
                    return BadRequest(await Result.FailAsync("Key is null or empty."));

                var appSetting = await _unitOfWork.AppSettings.GetFirstOrDefaultAsync(predicate: x => x.Key.Equals(key));
                if (appSetting is null)
                    return NotFound(await Result.FailAsync("AppSetting not found."));

                _unitOfWork.AppSettings.Remove(appSetting);
                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true,"AppSetting successfully deleted."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }

        /// <summary>
        /// Update AppSetting
        /// </summary>
        /// <param name="appSettingId"></param>
        /// <param name="request"></param>
        /// <returns>bool</returns>
        [HttpPatch("{appSettingId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> UpdateAppSettingById(string appSettingId, [FromBody] JsonPatchDocument<AppSettingsRequest> request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(appSettingId))
                    return BadRequest(await Result.FailAsync("AppSettingId is null or empty."));

                var appSetting = await _unitOfWork.AppSettings.FindAsync(Guid.Parse(appSettingId));
                if (appSetting is null)
                    return NotFound(await Result.FailAsync("AppSetting not found."));

                var requestToPatch = _mapper.Map<AppSettingsRequest>(appSetting);
                request.ApplyTo(requestToPatch);
                _mapper.Map(requestToPatch, appSetting);

                await _unitOfWork.SaveChangesAsync();
                return Ok(await Result<bool>.SuccessAsync(true,"AppSetting successfully updated."));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, await Result.FailAsync(ex.GetMessages().ToList()));
            }
        }
    }
}
