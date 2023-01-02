using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum RegionTypeEnum : short
{
    [Display(Description = "None"  , Order =0,AutoGenerateField = false)]
    None = 0,
    [Display(Description = "Country" , Order =1)]
    Country = 1,
    [Display(Description = "State", Order = 2)]
    State = 2,
    [Display(Description = "City", Order = 3)]
    City = 3,
    [Display(Description = "Village", Order = 4)]
    Village = 4,
    [Display(Description = "Other", Order = 1000, AutoGenerateField = false)]
    Other = 1000,


}
