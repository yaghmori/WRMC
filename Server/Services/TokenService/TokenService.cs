using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.Helpers;
using WRMC.Infrastructure.Domain.Entities;

namespace Server.Services.TokenService
{
    public class TokenService : ITokenService
    {

        public string GenerateRandomCode()
        {
            return new Random().Next(0, 1000000).ToString("D6");
        }

        public string GenerateRefreshToken(User user)
        {
            string refreshToken = null;
            if (user != null)
            {
                var jwtSecurityToken = GetTokenOptions(user, true);
                var tokenHandler = new JwtSecurityTokenHandler();
                refreshToken = tokenHandler.WriteToken(jwtSecurityToken);
            }
            return refreshToken;
        }

        public string GenerateJwtToken(User user)
        {
            string accessToken = null;
            if (user != null)
            {
                var jwtSecurityToken = GetTokenOptions(user, false);
                var tokenHandler = new JwtSecurityTokenHandler();
                accessToken = tokenHandler.WriteToken(jwtSecurityToken);
            }
            return accessToken;
        }

        public ClaimsPrincipal ValidateExpiredToken(string token)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateAudience = ConfigHelper.JwtSettings.ValidateAudience,
                ValidateIssuer = ConfigHelper.JwtSettings.ValidateIssuer,
                ValidIssuer = ConfigHelper.JwtSettings.Issuer,
                ValidAudience = ConfigHelper.JwtSettings.Audience,
                ValidateIssuerSigningKey = ConfigHelper.JwtSettings.ValidateIssuerSigningKey,
                ValidateLifetime = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigHelper.JwtSettings.SecurityKey)),
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

        public ClaimsPrincipal ValidateToken(string jwtToken)
        {

            IdentityModelEventSource.ShowPII = true;
            var validationParameters = new TokenValidationParameters
            {
                ValidateAudience = ConfigHelper.JwtSettings.ValidateAudience,
                ValidateIssuer = ConfigHelper.JwtSettings.ValidateIssuer,
                ValidIssuer = ConfigHelper.JwtSettings.Issuer,
                ValidAudience = ConfigHelper.JwtSettings.Audience,
                ValidateIssuerSigningKey = ConfigHelper.JwtSettings.ValidateIssuerSigningKey,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigHelper.JwtSettings.SecurityKey)),
            };
            SecurityToken securityToken;

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || jwtSecurityToken.ValidTo <= DateTime.UtcNow || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                principal = new ClaimsPrincipal();
            }

            return principal;
        }

        private List<Claim> GetClaims(User user)
        {

            var claims = new List<Claim>();
            if (user != null)
            {
                claims.Add(new Claim(AppClaimTypes.UserId, user.Id.ToString()));
                claims.Add(new Claim(AppClaimTypes.TenantId, user.DefaultTenantId.ToString()));
            }
            return claims;
        }

        private JwtSecurityToken GetTokenOptions(User user, bool isRefresh)
        {               
            var claims = GetClaims(user);

            var tokenOptions = new JwtSecurityToken(
                issuer: ConfigHelper.JwtSettings.Issuer,
                audience: ConfigHelper.JwtSettings.Audience,
                claims: claims,
                expires: isRefresh ? DateTime.UtcNow.AddDays(Convert.ToDouble(ConfigHelper.JwtSettings.RefreshTokenExpiryInDay)) : DateTime.UtcNow.AddMinutes(Convert.ToDouble(ConfigHelper.JwtSettings.TokenExpiryInMinutes)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigHelper.JwtSettings.SecurityKey)), SecurityAlgorithms.HmacSha256));
            return tokenOptions;
        }


    }
}
