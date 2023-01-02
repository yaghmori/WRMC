namespace WRMC.Core.Shared.Responses
{
    public class RoleClaimResponse
    {
        public string Id { get; set; } = default!;
        public string ClaimType { get; set; } = default!;
        public string ClaimValue { get; set; } = default!;
    }
}
