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