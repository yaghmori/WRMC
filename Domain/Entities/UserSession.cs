using System.ComponentModel.DataAnnotations.Schema;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class UserSession : BaseEntity<Guid>
    {
        [Column(Order = 1)]
        public Guid UserId { get; set; }
        [Column(Order = 2)]
        public  string? LoginProvider { get; set; } = default!;
        [Column(Order = 3)]
        public  string? BuildVersion { get; set; } = default!;
        [Column(Order = 4)]
        public string? Name { get; set; } = default!;
        [Column(Order = 5)]
        public string? AccessToken { get; set; } = default!;
        [Column(Order = 6)]
        public string? RefreshToken { get; set; } = default!;
        [Column(Order = 7)]
        public DateTime? RefreshTokenExpires { get; set; }
        [Column(Order = 8)]
        public DateTime? StartDate { get; set; }
        [Column(Order = 9)]
        public string? SessionIpAddress { get; set; }

        public virtual User User { get; set; }

    }
}
