using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class IntroMethod : BaseEntity<int>
    {
        [Column(Order = 1)]
        public int? ParentId { get; set; }

        [Column(Order = 2)]
        public virtual TreeTypeEnum Type { get; set; }

        [Column(Order = 3)]
        public short Order { get; set; }

        [Column(Order = 4)]
        public string Name { get; set; }

        [Column(Order = 5)]
        public string? DisplayTitle { get; set; }

        [Column(Order = 6)]
        public string? Description { get; set; }
        [Column(Order = 7)]
        public bool AdditionalInfoRequired { get; set; } = false;

        [Column(Order = 8)]
        public string? AdditionalInfoLabel { get; set; } 

        public virtual IntroMethod? Parent { get; set; }
        public virtual ICollection<IntroMethod> IntroMethods { get; set; } = new List<IntroMethod>();

        [NotMapped]
        public string? Path {
            get
            {
                if (Parent?.Parent?.Parent != null)
                    return Parent?.Parent?.Parent?.DisplayTitle + ", " + Parent?.Parent?.DisplayTitle + ", " + Parent?.DisplayTitle + ", " + DisplayTitle;

                if (Parent?.Parent != null)
                    return Parent?.Parent?.DisplayTitle + ", " + Parent?.DisplayTitle + ", " + DisplayTitle;

                if (Parent != null)
                    return Parent?.DisplayTitle + ", " + DisplayTitle;

                return DisplayTitle;
            }
}
    }
}
