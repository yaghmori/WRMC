using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class UserAddress : BaseEntity<Guid>
    {
        [Column(Order = 1)]
        public Guid UserId { get; set; }
        [Column(Order = 2)]
        public int? RegionId { get; set; }
        [Column(Order = 3)]
        public AddressTypeEnum? AddressType { get; set; }
        [Column(Order = 4)]
        public string Address { get; set; } = default!;
        [Column(Order = 5)]
        public string? ZipCode { get; set; }=default!;
        [Column(Order = 6)]
        public string? Description { get; set; }
        [Column(Order = 7)]
        public bool IsDefault { get; set; }
        [Column(Order = 8)]
        public int? Order { get; set; }

        public virtual User User { get; set; }
        public virtual Region? Region { get; set; }
    }
}
