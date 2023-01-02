using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Requests
{
    public class RegionRequest
    {
        
        public int? ParentId { get; set; }

        [Required]
        public virtual RegionTypeEnum RegionType { get; set; }

        [Required]
        public string Name { get; set; } = default!;
        public string? OfficialName { get; set; }
        public string? Iso2 { get; set; }
        public string? Iso3 { get; set; }
        public short? Numeric { get; set; }
        public string? Flag { get; set; }

    }
}
