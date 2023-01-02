using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum ReligionEnum : short
{
    [Display(Description = "Christian/Catholic", Order = 1)] ChristianCatholic = 0,
    [Display(Description = "Jewish", Order = 2)] Jewish = 1,
    [Display(Description = "Islam", Order = 3)] Islam = 2,
    [Display(Description = "Hindu", Order = 4)] Hindu = 3,
    [Display(Description = "Buddhist", Order = 5)] Buddhist = 4,
    [Display(Description = "Mormon", Order = 6)] Mormon = 5,
    [Display(Description = "Jehovah Witness", Order = 7)] JehovahWitness = 6,
    [Display(Description = "Atheist", Order = 8)] Atheist = 7,
    [Display(Description = "No Religious Affiliation", Order = 9)] NoReligiousAffiliation = 8,
    [Display(Description = "WICCA", Order = 10)] Wicca = 9,
}
