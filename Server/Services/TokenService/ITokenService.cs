using System.Security.Claims;
using WRMC.Infrastructure.Domain.Entities;

namespace Server.Services.TokenService
{
    public interface ITokenService
    {
        string GenerateRefreshToken(User user);
        string GenerateJwtToken(User user);
        string GenerateRandomCode();
        ClaimsPrincipal ValidateToken(string jwtToken);
        ClaimsPrincipal ValidateExpiredToken(string token);
    }
}
