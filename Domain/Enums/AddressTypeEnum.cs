using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum AddressTypeEnum : short
{
    [Display(Description = "None",  Order = 0, AutoGenerateField = false)]
    None = 0,
    [Display(Description = "Home", ShortName = "house", Order = 1)]
    Home = 1,
    [Display(Description = "Work", ShortName = "briefcase", Order = 2)]
    Work = 2,

    [Display(Description = "Other", ShortName = "file", Order = 1000)]
    Others = 1000,
}
