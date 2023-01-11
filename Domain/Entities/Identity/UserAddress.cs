using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class UserAddress : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public int? RegionId { get; set; }
        public AddressTypeEnum? Type { get; set; }
        public string Address { get; set; } = default!;
        public string? ZipCode { get; set; }=default!;
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
        public int? Order { get; set; }

        public virtual User User { get; set; }
        public virtual Region? Region { get; set; }
    }
}
