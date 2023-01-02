using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Responses
{
    public class UserProfileResponse
    {
        public string Id { get; set; }
        public string? UserId { get; set; }
        public string Email { get; set; }
        public string? IntroMethodId { get; set; }
        public IntroMethodResponse? IntroMethod { get; set; }
        public string? IntroMethodDescription { get; set; }
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

        public string FullName => $"{FirstName} {LastName}";

    }
}
