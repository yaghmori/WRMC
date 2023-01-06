using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Responses
{
    public class UserPhoneNumberResponse
    {
        public string Id { get; set; } = default!;
        public string UserId { get; set; }
        public virtual PhoneNumberTypeEnum? PhoneNumberType { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
        public int? Order { get; set; }

    }
}
