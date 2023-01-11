using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{


    public class Section : BaseEntity<Guid>
    {
        public Guid? ParentId { get; set; }
        public string Name { get; set; } = default!;
        public string? DisplayTitle { get; set; } = default!;
        public virtual SectionGroupEnum SectionGroup { get; set; }
        public virtual SectionTypeEnum SectionType { get; set; }
        public virtual SectionVisibilityEnum Visibility { get; set; }
        public GenderEnum Gender { get; set; }
        public int Order { get; set; } = default!;
        public bool IsRequired { get; set; } = default!;
        public string? Help { get; set; }
        public string? URI { get; set; }
        public string? Command { get; set; }
        public string? Image { get; set; }
        public string? RequiredPolicy { get; set; }

        public virtual Section? Parent { get; set; }
        public virtual ICollection<Tasks> VisitSections { get; set; } = new List<Tasks>();
        public virtual ICollection<Section> Sections { get; set; } = new List<Section>();








    }
}
