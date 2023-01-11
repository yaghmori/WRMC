using FluentValidation;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Requests;

public class SectionRequest
{
    public string? ParentId { get; set; }
    public string Name { get; set; } = default!;
    public string? DisplayTitle { get; set; } = default!;
    public int Order { get; set; } = default!;
    public bool IsRequired { get; set; } = default!;
    public SectionGroupEnum SectionGroup { get; set; }
    public SectionTypeEnum SectionType { get; set; }
    public SectionVisibilityEnum Visibility { get; set; }
    public GenderEnum Gender { get; set; }
    public string? Help { get; set; }
    public string? URI { get; set; }
    public string? Command { get; set; }
    public string? Image { get; set; }
    public string? RequiredPolicy { get; set; }


}

public class SectionValidator : AbstractValidator<SectionRequest>
{
    public SectionValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.DisplayTitle).NotEmpty().WithMessage("Display title is required");
        RuleFor(x => x.Order).NotEmpty().WithMessage("Order is required");
        RuleFor(x => x.IsRequired).NotEmpty().WithMessage("please specify if section is required");
        RuleFor(x => x.SectionGroup).NotNull().WithMessage("Section group is required");
        RuleFor(x => x.SectionType).NotNull().WithMessage("Section type is required");
        RuleFor(x => x.Visibility).NotNull().WithMessage("Visibility is required");
        RuleFor(x => x.Gender).NotNull().WithMessage("Gender is required");

    }
}