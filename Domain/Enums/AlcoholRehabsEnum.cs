using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum AlcoholRehabsEnum : short
{
    [Display(Description = "West Care Rehab", Order = 1)] WestCareRehab = 0,
    [Display(Description = "Center for Behavioral Health", Order = 2)] CenterForBehavioralHealth = 1,
    [Display(Description = "Other", Order = 1000)] Other = 1000,
}
