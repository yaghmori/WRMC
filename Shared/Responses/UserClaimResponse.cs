namespace WRMC.Core.Shared.Responses
{
    public class UserClaimResponse
    {
        public string Id { get; set; } = default!;
        public string ClaimType { get; set; } = default!;
        public string ClaimValue { get; set; } = default!;
    }
}
