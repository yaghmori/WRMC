using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class UserAttachment : BaseEntity<Guid>
    {
        [Column(Order = 1)]
        public Guid UserId { get; set; }
        [Column(Order = 2)]
        public virtual AttachmentTypeEnum? Type { get; set; }
        [Column(Order = 3)]
        public string URL { get; set; } = default!;
        [Column(Order = 4)]
        public string? Description { get; set; }
        [Column(Order = 5)]
        public bool IsDefault { get; set; }
        [Column(Order = 6)]
        public int? Order { get; set; }

        public virtual User User { get; set; }
    }
}
