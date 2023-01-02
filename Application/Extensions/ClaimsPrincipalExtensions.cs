using System.Security.Claims;
using WRMC.Core.Application.Extensions;
using WRMC.Core.Shared.Constant;

namespace WRMC.Core.Application.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetEmail(this ClaimsPrincipal principal)
            => principal.FindFirstValue(ApplicationClaimTypes.Email);

        public static string? GetTenant(this ClaimsPrincipal principal)
            => principal.FindFirstValue(ApplicationClaimTypes.Tenant);



        public static string? GetUserId(this ClaimsPrincipal principal)
           => principal.FindFirstValue(ApplicationClaimTypes.UserId);


        public static DateTimeOffset GetExpiration(this ClaimsPrincipal principal) =>
            DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(
                principal.FindFirstValue(ApplicationClaimTypes.Expiration)));

        private static string? FindFirstValue(this ClaimsPrincipal principal, string claimType) =>
            principal is null
                ? throw new ArgumentNullException(nameof(principal))
                : principal.FindFirst(claimType)?.Value;
    }
}
