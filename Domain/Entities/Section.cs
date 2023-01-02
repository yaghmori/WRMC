using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{


    public class Section : BaseEntity<Guid>
    {
        [Column(Order = 2)]
        public Guid? ParentId { get; set; }
        [Column(Order = 3)]
        public string Name { get; set; } = default!;
        [Column(Order = 4)]
        public string? DisplayTitle { get; set; } = default!;
        [Column(Order = 5)]
        public int Order { get; set; } = default!;
        [Column(Order = 6)]
        public bool IsRequired { get; set; } = default!;
        [Column(Order = 7)]
        public string? Help { get; set; }
        [Column(Order = 8)]
        public string? URI { get; set; }
        [Column(Order = 9)]
        public string? Command { get; set; }
        [Column(Order = 10)]
        public string? Image { get; set; }
        [Column(Order = 11)]
        public string? RequiredPolicy { get; set; }
        [Column(Order = 12)]
        public virtual SectionGroupEnum SectionGroup { get; set; }
        [Column(Order = 13)]
        public virtual SectionTypeEnum SectionType { get; set; }
        [Column(Order = 14)]
        public virtual SectionVisibilityEnum Visibility { get; set; }
        [Column(Order = 15)]
        public GenderEnum Sex { get; set; }
        public virtual Section? Parent { get; set; }
        public virtual ICollection<Tasks> VisitSections { get; set; } = new List<Tasks>();
        public virtual ICollection<Section> Sections { get; set; } = new List<Section>();








    }
}
