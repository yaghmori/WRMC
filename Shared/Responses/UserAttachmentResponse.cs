using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Responses
{
    public class UserAttachmentResponse
    {
        public string Id { get; set; } = default!;
        public string UserId { get; set; }
        public virtual AttachmentTypeEnum? Type { get; set; }
        public string URL { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
        public int? Order { get; set; }

    }
}
