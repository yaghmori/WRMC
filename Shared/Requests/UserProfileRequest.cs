using FluentValidation;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ValidationAttributes;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;
using WRMC.Infrastructure.Localization;

namespace WRMC.Core.Shared.Requests
{
    public class UserProfileRequest
    {
        public string? UserId { get; set; }
        public string? Email { get; set; }
        public string? IntroMethodId { get; set; }
        public IntroMethodResponse IntroMethod
        {
            get { return introMethod; }
            set
            {
                introMethod = value;
                IntroMethodId = value?.Id;
            }
        }

        private IntroMethodResponse introMethod = null;
        public bool? IsAdditionalInfoRequired => IntroMethod?.AdditionalInfoRequired;
        public string? IntroMethodDescription { get; set; }
        public GenderEnum? Gender { get; set; }
        public virtual RaceEnum? RaceNationality { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Description { get; set; }
        public string? ProfileImage { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? IdNumber { get; set; }
        public short? Height { get; set; }
        public short? Weight { get; set; }
        public string? EmergencyName { get; set; }
        public string? EmergencyPhone { get; set; }
        public bool? IsNoticeAccepted { get; set; }
        public bool? IsVolunteer { get; set; }

    }

    public class UserProfileValidator : AbstractValidator<UserProfileRequest>
    {
        public UserProfileValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Please specify a User Id");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Please specify a Email").EmailAddress().WithMessage("Please enter valid email address");
            RuleFor(x => x.IntroMethodDescription).NotEmpty().When(x => x.IsAdditionalInfoRequired == true).WithMessage("Please specify Additional Info");
            RuleFor(x => x.IntroMethod).NotNull().WithMessage("Please specify a Introduction method");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Please specify your gender");
            RuleFor(x => x.RaceNationality).NotEmpty().WithMessage("Please specify your Race Nationality");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please specify first name");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Please specify last name");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Please specify your birth date");
            RuleFor(x => x.IdNumber).NotEmpty().WithMessage("Please specify your social security number");
            RuleFor(x => x.Height).NotEmpty().When(x => x.Gender == GenderEnum.Female).WithMessage("Please specify your height");
            RuleFor(x => x.Weight).NotEmpty().When(x => x.Gender == GenderEnum.Female).WithMessage("Please specify your weight");
        }
    }

}
