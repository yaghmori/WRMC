namespace WRMC.Core.Shared.Responses
{
    public class UserSessionResponse
    {
        public string Id { get; set; } = default!;
        public virtual string LoginProvider { get; set; } = default!;
        public virtual string BuildVersion { get; set; } = default!;
        public string Name { get; set; } = default!;
        public DateTime? StartDate { get; set; }
        public string? SessionIpAddress { get; set; }
    }

}
