using System.Security.Claims;
using WRMC.Core.Shared.Constants;

namespace WRMC.Core.Shared.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetEmail(this ClaimsPrincipal principal)
            => principal.FindFirstValue(AppClaimTypes.Email);

        public static string? GetTenant(this ClaimsPrincipal principal)
            => principal.FindFirstValue(AppClaimTypes.Tenant);



        public static string? GetUserId(this ClaimsPrincipal principal)
           => principal.FindFirstValue(AppClaimTypes.UserId);


        public static DateTimeOffset GetExpiration(this ClaimsPrincipal principal) =>
            DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(
                principal.FindFirstValue(AppClaimTypes.Expiration)));

        private static string? FindFirstValue(this ClaimsPrincipal principal, string claimType) =>
            principal is null
                ? throw new ArgumentNullException(nameof(principal))
                : principal.FindFirst(claimType)?.Value;
    }
}
