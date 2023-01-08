using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class Tenant : BaseEntity<Guid>
    {

        [Column(Order = 2)]
        public string Name { get; set; }
        [Column(Order = 3)]
        public DateTime DateCreated { get; set; }
        [Column(Order = 4)]
        public string? Name2 { get; set; }
        [Column(Order = 5)]
        public string? Description { get; set; }
        [Column(Order = 6)]
        public bool IsActive { get; set; } = true;
        [Column(Order = 7)]  
        public DateTime ExpireDate { get; set; }
        [Column(Order = 8)]
        public string? Issuer { get; set; }
        [Column(Order = 9)]
        public virtual DbProviderKeyEnum? DBProvider { get; set; } = DbProviderKeyEnum.SqlServer;
        [Column(Order = 10)]
        public string ConnectionString { get; set; } = string.Empty;
        public virtual ICollection<UserTenant> UserTenants { get; set; } = new List<UserTenant>();



    }

}
