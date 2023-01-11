using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Services.TokenService;
using System.Data;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.Helpers;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork;
using WRMC.Server.Extensions;
using WRMC.Server.Services;

namespace WRMC.Server.Controllers
{
    [Route("api/v1/server/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISmtpService _messageSender;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenServices;
        private readonly bool _registerConfirmationRequired;
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(ISmtpService messageSender,
            IPasswordHasher<User> passwordHasher,
            IMapper mapper,
            IConfiguration configuration,
            ITokenService tokenServices,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _messageSender = messageSender;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
            _tokenServices = tokenServices;
            _registerConfirmationRequired = Convert.ToBoolean(_configuration.GetSection("RegisterConfirmationRequired").Value);
            _unitOfWork = unitOfWork;
        }




        /// <summary>
        /// Refresh Expired Token
        /// </summary>
        /// <param name="request"></param>
        /// <returns>TokenResponse</returns>
        [AllowAnonymous]
        [HttpPost("token/refresh")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenResponse))]
        public async Task<IActionResult> RefreshToken(TokenRequest request)
        {
            //Validate refresh token
            var userSession = await _unitOfWork.UserSessions.GetFirstOrDefaultAsync(predicate: x => x.RefreshToken == request.RefreshToken && x.AccessToken == request.Token);
            if (userSession is null)
                return BadRequest(await Result.FailAsync("Invalid Token."));

            if (userSession.RefreshTokenExpires <= DateTime.UtcNow)
                return BadRequest(await Result.FailAsync("Refresh Token is expired."));

            //var principal = _tokenServices.ValidateToken(request.RefreshToken);
            //var userId = principal?.FindFirst(x => x.Type.Equals(ApplicationClaimTypes.UserId))?.Value;
            //if (string.IsNullOrWhiteSpace(userId))
            //    return BadRequest(await Result.FailAsync("Invalid Token."));

            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id == userSession.UserId);
            if (user is null) return
                    BadRequest(await Result.FailAsync("User not found.")); //user deleted!

            userSession.AccessToken = _tokenServices.GenerateJwtToken(user);
            await _unitOfWork.SaveChangesAsync();
            var token = new TokenResponse
            {
                AccessToken = userSession.AccessToken,
                RefreshToken = userSession.RefreshToken
            };
            return Ok(await Result<TokenResponse>.SuccessAsync(token));


        }



        /// <summary>
        /// Login By Email
        /// </summary>
        /// <param name="request"></param>
        /// <returns>TokenResponse</returns>
        [AllowAnonymous]
        [HttpPost("token")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenResponse))]
        public async Task<IActionResult> GetToken(LoginByEmailRequest request)
        {

            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Email.Equals(request.Email));

            if (user == null)
                return BadRequest(await Result.FailAsync("Incorrect UserName or password."));

            if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
                return BadRequest(await Result.FailAsync("Incorrect UserName or password."));


            if (!user.IsActive)
            {
                return BadRequest(await Result.FailAsync("User Not Active. Please contact the administrator."));
            }



            var sessions = await _unitOfWork.UserSessions.GetAllAsync(predicate: x => x.UserId == user.Id);
            //TODO : Limit User only 1 active session at a time 
            if (sessions.Count > 5)
                return Conflict(await Result.FailAsync("Only 5 active session allowed at a time."));

            #region GenerateToken
            var session = new UserSession
            {
                UserId = user.Id,
                Name = Request.Headers.UserAgent.ToString(),
                LoginProvider = "IdentityServer",
                SessionIpAddress = HttpContext.Request?.HttpContext?.Connection?.RemoteIpAddress?.ToString(),
                StartDate = DateTime.UtcNow,
                BuildVersion = "v1",
                AccessToken = _tokenServices.GenerateJwtToken(user),
                RefreshToken = Guid.NewGuid().ToString(),
                RefreshTokenExpires = DateTime.UtcNow.AddDays(Convert.ToInt32(ConfigHelper.JwtSettings.RefreshTokenExpiryInDay)),
            };
            await _unitOfWork.UserSessions.AddAsync(session);
            await _unitOfWork.SaveChangesAsync();

            var token = new TokenResponse
            {
                AccessToken = session.AccessToken,
                RefreshToken = session.RefreshToken
            };

            #endregion

            return Ok(await Result<TokenResponse>.SuccessAsync(token));



        }

        /// <summary>
        /// Register email and password
        /// </summary>
        /// <param name="request"></param>
        /// <returns>TokenResponse</returns>
        [AllowAnonymous]
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (await _unitOfWork.Users.AnyAsync(a => a.Email != null && a.Email.Equals(request.Email)))
                return Conflict(await Result<TokenResponse>.FailAsync("Email is is already exist."));
            var user = _mapper.Map<User>(request);
            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            //Add User
            var userEntity = await _unitOfWork.Users.AddAsync(user);

            //Create UserSettings
            await _unitOfWork.UserSettings.AddAsync(new UserSetting
            {
                UserId = userEntity.Entity.Id,
                Culture = "en-US",
                DarkMode = false,
                RightToLeft = false,
            });

            //Create UserProfiles
            await _unitOfWork.UserProfiles.AddAsync(new UserProfile
            {
                UserId = userEntity.Entity.Id,

            });


            //Assign Default Role
            var clientRole = await _unitOfWork.Roles.GetFirstOrDefaultAsync(predicate: x => x.Name.Equals(AppRoles.Client));
            if (clientRole != null)
            {
                await _unitOfWork.UserRoles.AddAsync(new UserRole(userEntity.Entity.Id, clientRole.Id));
            }

            //TODO : Send Email Verification Code
            await _unitOfWork.SaveChangesAsync();

            return Ok(await Result<string>.SuccessAsync(userEntity.Entity.Id.ToString(), "User successfully created."));
            //if (result.Succeeded)
            //{
            //}
            //else
            //{
            //    return BadRequest(await Result<TokenResponse>.FailAsync(result.Errors.Select(x => x.Description).ToList()));
            //}


        }


        /// <summary>
        /// Register by Email (Two Factor)
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("RegisterByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> RegisterTwoFactor(string email)
        {
            if (email is null)
                return BadRequest(await Result<TokenResponse>.FailAsync("Email is null or empty."));

            if (await _unitOfWork.Users.AnyAsync(a => a.Email != null && a.Email.Equals(email)))
                return Conflict(await Result<TokenResponse>.FailAsync("The entered email is already registered."));

            var user = new User()
            {
                Email = email,
                UserName = email,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            //Create User
            var userEntity = await _unitOfWork.Users.AddAsync(user);
            //Create UserSettings
            await _unitOfWork.UserSettings.AddAsync(new UserSetting
            {
                UserId = user.Id,
                Culture = "en-US",
                DarkMode = false,
                RightToLeft = false,
            });
            //Create UserProfiles
            await _unitOfWork.UserProfiles.AddAsync(new UserProfile
            {
                UserId = user.Id,
            });
            //Assign Default Role
            var clientRole = await _unitOfWork.Roles.GetFirstOrDefaultAsync(predicate: x => x.Name.Equals(AppRoles.Client));
            if (clientRole != null)
            {
                await _unitOfWork.UserRoles.AddAsync(new UserRole(userEntity.Entity.Id, clientRole.Id));
            }
            await _unitOfWork.SaveChangesAsync();

            //TODO : Send Email Verification Code
            if (_registerConfirmationRequired)
            {
                try
                {
                    user.EmailToken = _tokenServices.GenerateRandomCode();
                    user.EmailTokenExpires = DateTime.UtcNow.AddHours(1);
                    await _messageSender.SendEmailAsync(user.Email, $"Email Confirmation Request {user.Email}", user.EmailToken, true);
                }
                catch
                {
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(user.PhoneNumber))
                    user.PhoneNumberConfirmed = true;
                else
                    user.PhoneNumberConfirmed = false;

                user.EmailConfirmed = true;
            }

            await _unitOfWork.SaveChangesAsync();

            return Ok(await Result<string>.SuccessAsync(userEntity.Entity.Id.ToString(), "User successfully created."));

        }


        /// <summary>
        /// verify phone number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="token"></param>
        /// <returns>TokenResponse</returns>
        [HttpPost("Verify-PhoneNumber")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenResponse))]
        public async Task<IActionResult> VerifyPhoneNumber(string phoneNumber, string token)
        {

            if (phoneNumber is null)
                return BadRequest(await Result<TokenResponse>.FailAsync("PhoneNumber is null or empty."));
            if (token is null)
                return BadRequest(await Result<TokenResponse>.FailAsync("Token is null or empty."));

            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.PhoneNumber.Equals(phoneNumber) && x.PhoneNumberToken == token);
            if (user is null)
            {
                return BadRequest(await Result<TokenResponse>.FailAsync("Invalid Token."));
            }
            if (user.PhoneNumberTokenExpires < DateTime.UtcNow)
            {
                return BadRequest(await Result<TokenResponse>.FailAsync("Token Expired."));
            }

            user.PhoneNumberToken = null;
            user.PhoneNumberConfirmed = true;
            await _unitOfWork.SaveChangesAsync();

            var tokenResponse = new TokenResponse
            {
                AccessToken = _tokenServices.GenerateJwtToken(user),
                RefreshToken = _tokenServices.GenerateRefreshToken(user)
            };
            return Ok(await Result<TokenResponse>.SuccessAsync(tokenResponse));


        }


        /// <summary>
        /// Verify Email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="token"></param>
        /// <returns>TokenResponse</returns>
        [HttpPost("Verify-Email")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenResponse))]
        public async Task<IActionResult> VerifyEmail(string email, string token)
        {

            if (email is null) return BadRequest(await Result<TokenResponse>.FailAsync("Email is null or empty."));
            if (token is null) return BadRequest(await Result<TokenResponse>.FailAsync("Token is null or empty."));

            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Email.Equals(email) && x.EmailToken == token);
            if (user is null)
            {
                return BadRequest(await Result<TokenResponse>.FailAsync("Invalid Token."));
            }
            if (user.EmailTokenExpires < DateTime.UtcNow)
            {
                return BadRequest(await Result<TokenResponse>.FailAsync("Token Expired."));
            }

            user.EmailToken = null;
            user.EmailConfirmed = true;
            await _unitOfWork.SaveChangesAsync();
            var tokenResponse = new TokenResponse
            {
                AccessToken = _tokenServices.GenerateJwtToken(user),
                RefreshToken = _tokenServices.GenerateRefreshToken(user)
            };
            return Ok(await Result<TokenResponse>.SuccessAsync(tokenResponse));

        }


        /// <summary>
        /// Login by phone number (Two Factor) - send token on sms if phone number exist
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        [HttpPost("Login/TwoFactor/PhoneNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> TwoFactorLoginByPhoneNumber(string phoneNumber)
        {

            if (phoneNumber is null) return BadRequest(await Result.FailAsync("PhoneNumber is null or empty."));

            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.PhoneNumber.Equals(phoneNumber));
            if (user is not null)
            {
                user.PhoneNumberToken = _tokenServices.GenerateRandomCode();
                user.PhoneNumberTokenExpires = DateTime.UtcNow.AddHours(1);
                await _messageSender.SendEmailAsync(user.Email, $"کد ورود به برنامه شماره {user.PhoneNumber}", user.PhoneNumberToken, true);
                await _unitOfWork.SaveChangesAsync();
            }
            return Ok(await Result.SuccessAsync("Verification token sent."));

        }


        /// <summary>
        /// Login by email (Two Factor) - send token on email if email exist
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("Login/TwoFactor/Email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> TwoFactorLoginByEmail(string email)
        {

            if (email is null) return BadRequest(await Result.FailAsync("Email is null or empty."));

            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Email.Equals(email));
            if (user is not null)
            {
                user.PhoneNumberToken = _tokenServices.GenerateRandomCode();
                user.PhoneNumberTokenExpires = DateTime.UtcNow.AddHours(1);
                await _messageSender.SendEmailAsync(user.Email, $"کد ورود به برنامه ایمیل {user.Email}", user.PhoneNumberToken, true);
                await _unitOfWork.SaveChangesAsync();
            }
            return Ok(await Result.SuccessAsync("Verification token sent."));

        }




        /// <summary>
        /// Send forgot password token via email
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("{userId}/Forgot-Password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPasswordByUserId(string userId)
        {
            if (userId is null)
                return BadRequest(await Result.FailAsync("UserId is null or empty."));
            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
            if (user is not null)
            {
                user.PasswordToken = _tokenServices.GenerateRandomCode();
                user.PasswordTokenExpires = DateTime.UtcNow.AddHours(1);
                await _messageSender.SendEmailAsync(user.Email, $"بازیابی کلمه عبور کاربر {user.UserName}", user.PasswordToken, true);
                await _unitOfWork.SaveChangesAsync();
            }
            return Ok(await Result.SuccessAsync("Verification token sent."));

        }




        /// <summary>
        /// Send forgot password token via email 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Forgot-Password/Email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ForgotPasswordByEmail(string email)
        {

            if (email is null) return BadRequest(await Result.FailAsync("UserName is null or empty."));

            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Email.Equals(email));
            if (user is not null)
            {
                user.PasswordToken = _tokenServices.GenerateRandomCode();
                user.PasswordTokenExpires = DateTime.UtcNow.AddHours(1);
                await _messageSender.SendEmailAsync(user.Email, $"بازیابی کلمه عبور ایمیل {user.Email}", user.PasswordToken, true);
                await _unitOfWork.SaveChangesAsync();
            }
            return Ok(await Result.SuccessAsync("Verification token sent."));

        }


        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{userId}/Reset-Password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ResetPassword(string userId, [FromBody] ResetPasswordRequest request)
        {


            if (userId is null) return BadRequest(await Result.FailAsync("UserId is null or empty."));
            var user = await _unitOfWork.Users.FindAsync(Guid.Parse(userId));
            if (user is null)
            {
                return NotFound(await Result.FailAsync("User not found."));
            }
            if (!user.PasswordToken.Equals(request.Token))
            {
                return BadRequest(await Result.FailAsync("Invalid Token."));
            }
            if (user.PasswordTokenExpires < DateTime.UtcNow)
            {
                return BadRequest(await Result.FailAsync("Token Expired."));
            }


            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.PasswordToken = null;
            user.PasswordTokenExpires = null;
            user.PasswordResetAt = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();
            return Ok(await Result.SuccessAsync("Password successfully reset."));


        }



    }

}

