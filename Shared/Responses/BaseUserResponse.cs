namespace WRMC.Core.Shared.Responses
{
    public class BaseUserResponse
    {

        public string Id { get; set; }
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string? FirstName { get; set; } = default!;
        public string? LastName { get; set; } = default!;
        public string? ProfileImage { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public bool IsActive { get; set; } = true;
        public string FullName => $"{FirstName} {LastName}";

    }
}
