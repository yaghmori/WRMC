using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Responses
{
    public class RegionResponse
    {
        public string Id { get; set; } = default!;
        public string? ParentId { get; set; }
        public RegionResponse? Parent { get; set; }
        public virtual RegionTypeEnum RegionType { get; set; }
        public string Name { get; set; } = default!;
        public string? OfficialName { get; set; }
        public string? Iso3 { get; set; }
        public string? Iso2 { get; set; }
        public string? Flag { get; set; }
        public short? Numeric { get; set; }
        public bool IsExpanded { get; set; }
        public bool HasChild => Regions.Count > 0;
        public string? Path { get; set; }
        public string Icon
        {
            get
            {
                switch (RegionType)
                {
                    case RegionTypeEnum.Country:
                        return Iso2;
                    case RegionTypeEnum.State:
                        return "fad fa-folders text-warning";
                    default:
                        return "far fa-window-maximize text-primary";//leaf
                }
            }
        }
        public string Color
        {
            get
            {
                switch (RegionType)
                {
                    case RegionTypeEnum.City:
                        return "text-primary";
                    default:
                        return "";
                }
            }
        }
        public virtual ICollection<RegionResponse> Regions { get; set; } = new List<RegionResponse>();
        public int UserAddressesCount { get; set; }= default!;

    }
}
