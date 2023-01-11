using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Requests
{
    public class RegionRequest
    {
        
        public int? ParentId { get; set; }
        public virtual RegionTypeEnum RegionType { get; set; }
        public string Name { get; set; } = default!;
        public string? OfficialName { get; set; }
        public string? Iso2 { get; set; }
        public string? Iso3 { get; set; }
        public short? Numeric { get; set; }
        public string? Flag { get; set; }

    }
    public class RegionValidator : AbstractValidator<RegionRequest>
    {
        public RegionValidator()
        {
            RuleFor(x => x.ParentId).NotEmpty().WithMessage("ParentId is required"); //TODO : Localization
            RuleFor(x => x.RegionType).NotEmpty().WithMessage("Region type is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
