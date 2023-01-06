using System.ComponentModel.DataAnnotations;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Requests
{
    public class UserAttachmentRequest
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public virtual AttachmentTypeEnum? Type { get; set; }
        [Required]
        public string URL { get; set; } = default!;
        public string? Description { get; set; }
        [Required]
        public bool IsDefault { get; set; } = false;
        public int? Order { get; set; }
    }

}
