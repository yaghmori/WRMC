using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum TobaccoFreqEnum : short
{
    [Display(Description = "Heavy (Over one pack a day)", Order = 3)] Heavy = 0,
    [Display(Description = "Average (10 cigarettes to one pack a day)", Order = 2)] Average = 1,
    [Display(Description = "Light (1 to 10 cigarettes a day)", Order = 1)] Light = 2,
}
