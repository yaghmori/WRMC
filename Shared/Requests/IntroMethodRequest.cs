using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Core.Shared.ValidationAttributes;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Requests
{
    public class IntroMethodRequest
    {

        public string? ParentId { get; set; }

        [Required]
        public virtual TreeTypeEnum Type { get; set; }

        [Required]
        public short Order { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string? DisplayTitle { get; set; }

        [Required]
        public bool AdditionalInfoRequired { get; set; } = false;

        [RequiredIf(nameof(AdditionalInfoRequired),true)]
        public string? AdditionalInfoLabel { get; set; }

        public string? Description { get; set; }


    }
}
