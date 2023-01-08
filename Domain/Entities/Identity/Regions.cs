using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class Region : BaseEntity<int>
    {
        [Column(Order = 1)]
        public int? ParentId { get; set; }
        [Column(Order = 2)]
        public virtual RegionTypeEnum RegionType { get; set; }
        [Column(Order = 3)]
        public string Name { get; set; } = default!;
        [Column(Order = 4)]

        public string? OfficialName { get; set; }
        [Column(Order = 5)]
        public string? Iso2 { get; set; }
        [Column(Order = 6)]
        public string? Iso3 { get; set; }
        [Column(Order = 7)]
        public short? Numeric { get; set; }
        [Column(Order = 8)]
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
