using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WRMC.Infrastructure.Domain.Enums;


public enum GenderEnum : short
{
    [Display(Description ="Female")] //TODO : Localization
    Female = 0,
    [Display(Description = "Male")]
    Male = 1,
}
