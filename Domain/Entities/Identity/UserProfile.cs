using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class UserProfile : BaseEntity<Guid>
    {

        public Guid UserId { get; set; }
        public int? IntroMethodId { get; set; }
        public bool? IsNoticeAccepted { get; set; }
        public bool? IsVolunteer { get; set; }
        public virtual GenderEnum? Gender { get; set; }
        public virtual RaceEnum? RaceNationality { get; set; }
        public string? IdNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime? BirthDate { get; set; }
        public short? Height { get; set; }
        public short? Weight { get; set; }
        public string? EmergencyName { get; set; }
        public string? EmergencyPhone { get; set; }
        public string? ProfileImage { get; set; }
        public string? Description { get; set; }
        public string? IntroMethodDescription { get; set; }
        public virtual User User { get; set; }
        public virtual IntroMethod? IntroMethod { get; set; }
    }
}
