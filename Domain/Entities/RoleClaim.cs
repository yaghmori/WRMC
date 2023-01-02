using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class RoleClaim : IdentityRoleClaim<Guid>,IAuditEntity
    {
        [Column(Order = 0)]
        public override  int Id { get; set; } = default!;
        [Column(Order = 1)]
        public override Guid RoleId { get; set; } = default!;
        [Column(Order = 2)]
        public override string? ClaimType { get; set; }
        [Column(Order = 3)]
        public override string? ClaimValue { get; set; }
        public virtual Role Role { get; set; }

        #region AuditEntity
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public string? CreatedUserId { get; set; }
        public string? CreatedIpAddress { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedUserId { get; set; }
        public string? ModifiedIpAddress { get; set; }

        public DateTime? DeletedDate { get; set; }
        public string? DeletedUserId { get; set; }
        public string? DeletedIpAddress { get; set; }
        public bool IsDeleted { get; set; } = false;
        #endregion

    }

}
