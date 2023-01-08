using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class UserProfile : BaseEntity<Guid>
    {

        [Column(Order = 1)]
        public Guid UserId { get; set; }

        [Column(Order = 2)]
        public int? IntroMethodId { get; set; }

        [Column(Order = 3)]
        public bool? IsNoticeAccepted { get; set; }

        [Column(Order = 4)]
        public bool? IsVolunteer { get; set; }

        [Column(Order = 5)]
        public virtual GenderEnum? Gender { get; set; }

        [Column(Order = 6)]
        public virtual RaceEnum? RaceNationality { get; set; }

        [Column(Order = 7)]
        public string? IdNumber { get; set; }

        [Column(Order = 8)]
        public string? FirstName { get; set; }

        [Column(Order = 9)]
        public string? LastName { get; set; }

        [Column(Order = 10)]
        public string? MiddleName { get; set; }

        [Column(Order = 11)]
        public DateTime? BirthDate { get; set; }

        [Column(Order = 12)]
        public short? Height { get; set; }

        [Column(Order = 13)]
        public short? Weight { get; set; }

        [Column(Order = 14)]
        public string? EmergencyName { get; set; }

        [Column(Order = 15)]
        public string? EmergencyPhone { get; set; }

        [Column(Order = 16)]
        public string? ProfileImage { get; set; }

        [Column(Order = 17)]
        public string? Description { get; set; }

        [Column(Order = 18)]
        public string? IntroMethodDescription { get; set; }


        public virtual User User { get; set; }
    }
}
