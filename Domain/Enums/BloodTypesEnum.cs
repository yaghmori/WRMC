using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum BloodTypesEnum : short
{
    [Display(Description = "I don't know", Order = 1)] NoInfo = 0,
    [Display(Description = "A+", Order = 2)] APositive = 1,
    [Display(Description = "A-", Order = 3)] ANegative = 2,
    [Display(Description = "B+", Order = 4)] BPositive = 3,
    [Display(Description = "B-", Order = 5)] BNegative = 4,
    [Display(Description = "O+", Order = 6)] OPositive = 5,
    [Display(Description = "O-", Order = 7)] ONegative = 6,
    [Display(Description = "AB+", Order = 8)] ABPositive = 7,
    [Display(Description = "AB-", Order = 9)] ABNegative = 8,
}
