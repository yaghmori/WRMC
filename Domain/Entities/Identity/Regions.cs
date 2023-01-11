using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class Region : BaseEntity<int>
    {
        public int? ParentId { get; set; }
        public virtual RegionTypeEnum RegionType { get; set; }
        public string Name { get; set; } = default!;
        public string? OfficialName { get; set; }
        public string? Iso2 { get; set; }
        public string? Iso3 { get; set; }
        public short? Numeric { get; set; }
        public string? Flag { get; set; }
        public virtual Region? Parent { get; set; }

        [NotMapped]
        public string? Path
        {
            get
            {
                if (Parent?.Parent?.Parent != null) //village
                    return Parent?.Parent?.Parent?.Iso3 + ", " + Parent?.Parent?.Name + ", " + Parent?.Name + ", " + Name;

                if (Parent?.Parent != null) //city
                    return Parent?.Parent?.Name + ", " + Parent?.Name + ", " + Name;

                if (Parent != null)// state
                    return Parent?.Name + ", " + Name;

                return Name;//country
            }
        }
        public virtual ICollection<Region> Regions { get; set; } = new List<Region>();
        public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();

    }
}
