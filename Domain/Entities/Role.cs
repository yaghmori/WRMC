using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class Role : IdentityRole<Guid>, IAuditEntity
    {

        public Role()
        {
        }

        public Role(string roleName) : base(roleName)
        {
            NormalizedName = roleName.Normalize().ToUpper();
        }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<RoleClaim> RoleClaims { get; set; } = new List<RoleClaim>();

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
