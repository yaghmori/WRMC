using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Responses
{
    public class TenantResponse
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public virtual DbProviderKeyEnum? DBProvider { get; set; }
        public string? ConnectionString { get; set; }=string.Empty;
        public DateTime? ExpireDate { get; set; }
        public List<UserResponse> Users { get; set; } = new();
        public int UsersCount => Users.Count;
        public bool Accessable => ExpireDate > DateTime.UtcNow && IsActive;
        public bool NormalizedName { get; set; }

    }

}
