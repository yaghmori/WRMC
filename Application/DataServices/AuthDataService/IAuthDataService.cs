using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{
    public interface IAuthDataService
    {
        Task<IResult<bool>> IsDupplicateEmailAsync(string email);
        Task<IResult<bool>> IsExistUserNameAsync(string userName);
        Task<IResult<TokenResponse>> GetTokenAsync(LoginByEmailRequest loginRequest);
        Task<IResult<TokenResponse>> RefreshToken(string jwtToken, string refreshToken);
        Task<IResult<string>> RegisterAsync(RegisterRequest registerRequest);
        Task<IResult<bool>> TwoFactorLoginByPhoneNumber(string phoneNumber);
        Task<IResult<bool>> TwoFactorRegisterByPhoneNumberAsync(string phoneNumber);
        Task<IResult<bool>> VerifyEmailAsync(string email, string token);
        Task<IResult<TokenResponse>> VerifyPhoneNumberAsync(string phoneNumber, string token);
    }
}