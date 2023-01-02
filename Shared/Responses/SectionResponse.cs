using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Responses;

public class SectionResponse
{
    public string Id { get; set; }
    public string? ParentId { get; set; }
    public SectionResponse Parent { get; set; }
    public string Name { get; set; } = default!;
    public string? DisplayTitle { get; set; }
    public string? Help { get; set; }
    public string? URI { get; set; }
    public string? Command { get; set; }
    public string? Image { get; set; }
    public string? RequiredPolicy { get; set; }
    public int Order { get; set; }
    public bool IsRequired { get; set; } = default!;
    public SectionGroupEnum SectionGroup { get; set; }
    public SectionTypeEnum SectionType { get; set; }
    public SectionVisibilityEnum Visibility { get; set; }
    public GenderEnum Gender { get; set; }
    //=====================================================================
   // public virtual ICollection<SectionResponse> Sections { get; set; } = new List<SectionResponse>();
}