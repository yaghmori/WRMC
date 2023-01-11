using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class IntroMethod : BaseEntity<int>
    {
        public int? ParentId { get; set; }
        public virtual TreeTypeEnum Type { get; set; }
        public short Order { get; set; }
        public string Name { get; set; }
        public string? DisplayTitle { get; set; }
        public string? Description { get; set; }
        public bool AdditionalInfoRequired { get; set; } = false;
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
