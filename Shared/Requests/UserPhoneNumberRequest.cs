using System.ComponentModel.DataAnnotations;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Requests
{
    public class UserPhoneNumberRequest
    {


        [Required]
        public  PhoneNumberTypeEnum? PhoneNumberType { get; set; }

        [Required]
        public string PhoneNumber { get; set; } = default!;


        public string? Description { get; set; }

        public bool IsDefault { get; set; } = false;
        public int? Order { get; set; }
    }

}
