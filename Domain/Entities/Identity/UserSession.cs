using System.ComponentModel.DataAnnotations.Schema;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class UserSession : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public string? ConnectionID { get; set; }
        public string? LoginProvider { get; set; } = default!;
        public string? BuildVersion { get; set; } = default!;
        public string? Name { get; set; } = default!;
        public string? AccessToken { get; set; } = default!;
        public string? RefreshToken { get; set; } = default!;
        public DateTime? RefreshTokenExpires { get; set; }
        public DateTime? StartDate { get; set; }
        public string? SessionIpAddress { get; set; }
        public virtual User User { get; set; }

    }
}
