using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum ProofIdentityEnum : short
{
    [Display(Description = "Valid driver's license", Order = 1)] ValidDriversLicense = 0,
    [Display(Description = "Learner's permit", Order = 2)] LearnersPermit = 1,
    [Display(Description = "State-issued identification card", Order = 3)] IdCard = 2,
    [Display(Description = "Homeless ID card", Order = 4)] HomelessIdCard = 3,
    [Display(Description = "Passport", Order = 5)] Passport = 4,
    [Display(Description = "Consular identification card", Order = 6)] ConsularIdCard = 5,
    [Display(Description = "Military ID", Order = 7)] MilitaryId = 6,
    [Display(Description = "Other", Order = 1000)] Other = 1000,
}
