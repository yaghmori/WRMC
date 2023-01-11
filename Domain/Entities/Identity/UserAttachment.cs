using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class UserAttachment : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public virtual AttachmentTypeEnum? Type { get; set; }
        public string URL { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
        public int? Order { get; set; }

        public virtual User User { get; set; }
    }
}
