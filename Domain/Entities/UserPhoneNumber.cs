using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class UserPhoneNumber : BaseEntity<Guid>
    {
        [Column(Order = 1)]
        public Guid UserId { get; set; }
        [Column(Order = 2)]
        public virtual PhoneNumberTypeEnum? PhoneNumberType { get; set; }
        [Column(Order = 3)]
        public string PhoneNumber { get; set; } = default!;
        [Column(Order = 4)]
        public string? Description { get; set; }
        [Column(Order = 5)]
        public bool IsDefault { get; set; }
        [Column(Order = 6)]
        public int? Order { get; set; }

        public virtual User User { get; set; }
    }
}
