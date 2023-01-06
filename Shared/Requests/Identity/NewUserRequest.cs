using System.ComponentModel.DataAnnotations;
using WRMC.Infrastructure.Domain.Enums;
using WRMC.Infrastructure.Localization;

namespace WRMC.Core.Shared.Requests
{
    public class NewUserRequest : RegisterRequest
    {

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Display(Name = nameof(Gender), ResourceType = typeof(DisplayResources))]
        public GenderEnum Gender { get; set; }


    }
}
