using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum AlcoholFreqEnum : short
{
    [Display(Description = "Very Heavy (5+ a day)", Order = 4)] VeryHeavy = 0,
    [Display(Description = "Heavy (3 to 4 a day)", Order = 3)] Heavy = 1,
    [Display(Description = "Moderate (1 to 3 a day)", Order = 2)] Moderate = 2,
    [Display(Description = "Light (< 1 a day)", Order = 1)] Light = 3,
}
