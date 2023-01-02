using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class UserToken : IdentityUserToken<Guid>, IAuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public Guid Id { get; set; }

        public virtual User User { get; set; }

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
