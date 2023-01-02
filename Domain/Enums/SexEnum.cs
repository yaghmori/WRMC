using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WRMC.Infrastructure.Domain.Enums;


public enum GenderEnum : short
{
    [Display(Description ="I am female")]
    Female = 0,
    [Display(Description = "I am male")]
    Male = 1,
}
