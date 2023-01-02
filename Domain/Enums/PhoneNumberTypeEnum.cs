using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum PhoneNumberTypeEnum : short
{
    [Display(Description = "None", Order = 0, AutoGenerateField = false)]
    None = 0,
    [Display(Description = "Mobile", ShortName = "mobile-screen-button", Order = 1)]
    Mobile = 1,
    [Display(Description = "WorkMobile", ShortName = "mobile-screen-button", Order = 2)]
    WorkMobile = 2,
    [Display(Description = "Work", ShortName = "phone-office", Order = 3)]
    Work = 3,
    [Display(Description = "Fax", ShortName = "fax", Order = 4)]
    Fax = 4,
    [Display(Description = "Emergency", ShortName = "light-emergency-on", Order = 5)]
    Emergency = 5,
    [Display(Description = "Home", ShortName = "phone-rotary", Order = 6)]
    Home = 6,
    [Display(Description = "Other", ShortName = "square-phone", Order = 1000)]
    Other = 1000,
}
