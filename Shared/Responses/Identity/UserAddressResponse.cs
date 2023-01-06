using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Responses
{
    public class UserAddressResponse
    {
        public string? Id { get; set; } = default!;
        public string? UserId { get; set; }
        public string? RegionId { get; set; }
        public virtual RegionResponse? Region { get; set; }
        public AddressTypeEnum? AddressType { get; set; }
        public string? Address { get; set; } = default!;
        public string? ZipCode { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
        public int? Order { get; set; }
    }
}
