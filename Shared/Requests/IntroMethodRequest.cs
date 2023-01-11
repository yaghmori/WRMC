using FluentValidation;
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
        public virtual TreeTypeEnum Type { get; set; }
        public short Order { get; set; }
        public string Name { get; set; }
        public string? DisplayTitle { get; set; }
        public bool AdditionalInfoRequired { get; set; } = false;
        public string? AdditionalInfoLabel { get; set; }
        public string? Description { get; set; }


    }

    public class IntroMethodValidator : AbstractValidator<IntroMethodRequest>
    {
        public IntroMethodValidator()
        {
            RuleFor(x => x.ParentId).NotEmpty().WithMessage("ParentId is required"); //TODO : Localization
            RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.DisplayTitle).NotEmpty().WithMessage("DisplayTitle is required");
            RuleFor(x => x.AdditionalInfoRequired).NotEmpty().WithMessage("Please specify if additional info is required");
            RuleFor(x => x.AdditionalInfoLabel).NotEmpty().When(x=>x.AdditionalInfoRequired==true).WithMessage("Please specify additional info label");
        }
    }
}
