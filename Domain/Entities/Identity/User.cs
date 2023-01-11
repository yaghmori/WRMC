using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class User : IdentityUser<Guid>, IAuditEntity
    {
        public User()
        {

        }
        public string? DefaultTenantId { get; set; }
        public string? EmailToken { get; set; }
        public DateTime? EmailTokenExpires { get; set; }
        public string? PhoneNumberToken { get; set; }
        public DateTime? PhoneNumberTokenExpires { get; set; }
        public string? PasswordToken { get; set; }
        public DateTime? PasswordTokenExpires { get; set; }
        public DateTime? PasswordResetAt { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsOnline { get; set; } = true;

        public virtual UserSetting UserSetting { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public virtual ICollection<UserAttachment> UserImages { get; set; } = new List<UserAttachment>();
        public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
        public virtual ICollection<UserPhoneNumber> UserPhoneNumbers { get; set; } = new List<UserPhoneNumber>();
        public virtual ICollection<UserClaim> UserClaims { get; set; } = new List<UserClaim>();
        public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
        public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
        public virtual ICollection<UserSession> UserSessions { get; set; } = new List<UserSession>();
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public virtual ICollection<Case> Cases { get; set; } = new List<Case>();

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
