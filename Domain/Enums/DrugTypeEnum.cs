using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum DrugTypeEnum : short
{
    [Display(Description = "Marijuana", Order = 1)] Marijuana = 0,
    [Display(Description = "Cocaine", Order = 2)] Cocaine = 1,
    [Display(Description = "Meth", Order = 3)] Meth = 2,
    [Display(Description = "Opioids", Order = 4)] Opioids = 3,
    [Display(Description = "Heroin", Order = 5)] Heroin = 4,
    [Display(Description = "LSD", Order = 6)] LSD = 5,
    [Display(Description = "PCP", Order = 7)] PCP = 6,
    [Display(Description = "Ecstasy/Molly", Order = 8)] EcstasyMolly = 7,
    [Display(Description = "Prescription Drugs", Order = 9)] PrescriptionDrugs = 8,
    [Display(Description = "Over-the-Counter", Order = 10)] OverTheCounter = 9,
}
