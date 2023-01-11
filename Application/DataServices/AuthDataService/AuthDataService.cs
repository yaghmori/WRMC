using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.Extensions;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
namespace WRMC.Core.Application.DataServices
{


    public class AuthDataService : DataServiceBase, IAuthDataService
    {

        public AuthDataService(IHttpClientFactory httpClient) : base(httpClient)
        {

        }

        public async Task<IResult<string>> RegisterAsync(RegisterRequest registerRequest)
        {
            var uri = EndPoints.AuthController.Register;
            var content = new StringContent(JsonConvert.SerializeObject(registerRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }

        public async Task<IResult<TokenResponse>> GetTokenAsync(LoginByEmailRequest loginRequest)
        {
            var uri = EndPoints.AuthController.GetToken;
            var content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<TokenResponse>();
        }

        public async Task<IResult<bool>> TwoFactorRegisterByPhoneNumberAsync(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return await Result<bool>.FailAsync("PhoneNumber is null or empty.");

            var uri = EndPoints.AuthController.RegisterByPhoneNumber;
            uri = QueryHelpers.AddQueryString(uri, nameof(phoneNumber), phoneNumber);
            var response = await _httpClient.PostAsync(uri, null);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> TwoFactorLoginByPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return await Result<bool>.FailAsync("PhoneNumber is null or empty.");

            var uri = EndPoints.AuthController.TwoFactorLoginByPhoneNumber;
            uri = QueryHelpers.AddQueryString(uri, nameof(phoneNumber), phoneNumber);
            var response = await _httpClient.PostAsync(uri, null);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<TokenResponse>> VerifyPhoneNumberAsync(string phoneNumber, string token)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return await Result<TokenResponse>.FailAsync("PhoneNumber is null or empty.");

            if (string.IsNullOrWhiteSpace(token))
                return await Result<TokenResponse>.FailAsync("Token is null or empty.");

            var uri = EndPoints.AuthController.VerifyPhoneNumber;
            uri = QueryHelpers.AddQueryString(uri, nameof(phoneNumber), phoneNumber);
            uri = QueryHelpers.AddQueryString(uri, nameof(token), token);
            var response = await _httpClient.PostAsync(uri, null);
            return await response.ToResult<TokenResponse>();
        }

        public async Task<IResult<bool>> VerifyEmailAsync(string email, string token)
        {
            if (string.IsNullOrWhiteSpace(email))
                return await Result<bool>.FailAsync("Email is null or empty.");

            if (string.IsNullOrWhiteSpace(token))
                return await Result<bool>.FailAsync("Token is null or empty.");

            var uri = EndPoints.AuthController.VerifyEmail;
            uri = QueryHelpers.AddQueryString(uri, nameof(email), email);
            uri = QueryHelpers.AddQueryString(uri, nameof(token), token);
            var response = await _httpClient.PostAsync(uri, null);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> IsExistUserNameAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return await Result<bool>.FailAsync("UserName is null or empty.");

            var uri = EndPoints.AuthController.IsDupplicateByUserName;
            uri = QueryHelpers.AddQueryString(uri, nameof(userName), userName);
            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> IsDupplicateEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return await Result<bool>.FailAsync("Email is null or empty.");

            var uri = EndPoints.AuthController.IsDupplicateByEmail;
            uri = QueryHelpers.AddQueryString(uri, nameof(email), email);
            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<TokenResponse>> RefreshToken(string jwtToken, string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(jwtToken))
                return await Result<TokenResponse>.FailAsync("JwtToken is null or empty.");

            if (string.IsNullOrWhiteSpace(refreshToken))
                return await Result<TokenResponse>.FailAsync("RefreshToken is null or empty.");

            var content = new StringContent(JsonConvert.SerializeObject(new TokenRequest
            {
                Token = jwtToken,
                RefreshToken = refreshToken
            }), Encoding.UTF8, "application/json");
            var uri = string.Format(EndPoints.AuthController.RefreshToken);
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<TokenResponse>();
        }
    }
}
