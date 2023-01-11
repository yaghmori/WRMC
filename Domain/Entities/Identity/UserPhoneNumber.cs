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
        public Guid UserId { get; set; }
        public virtual PhoneNumberTypeEnum? Type { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
        public int? Order { get; set; }

        public virtual User User { get; set; }
    }
}
