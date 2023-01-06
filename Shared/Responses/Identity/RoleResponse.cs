namespace WRMC.Core.Shared.Responses
{
    public class RoleResponse
    {
        public string Id { get; set; } = default!;
        public string? Name { get; set; } = default!;
        public int UsersCount { get; set; } = default!;
        public int ClaimCount { get; set; } = default!;
    }
}
