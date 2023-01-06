using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WRMC.Core.Shared.Helpers;
using WRMC.Core.Shared.Models;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Server.Extensions;

namespace WRMC.Server.Controllers
{
    [Route("api/v1/server/config")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        public ConfigController()
        {
        }



        [HttpGet("JwtSettings")]
        public async Task<IActionResult> GetJwtSettings()
        {
                return Ok(await Result<JwtSettings>.SuccessAsync(ConfigHelper.JwtSettings));
        }
        [HttpGet("SmtpSettings")]
        public async Task<IActionResult> GetSmtpSettings()
        {
                return Ok(await Result<SmtpSettings>.SuccessAsync(ConfigHelper.SmtpSettings));
        }

        [HttpGet("TokenValidationParameters")]
        public async Task<IActionResult> GetValidationParameters()
        {

                return Ok(await Result<TokenValidationParameters>.SuccessAsync(ConfigHelper.ValidationParameters));
           
        }




    }
}
