using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum ImmigrationStatusEnum : short
{
    [Display(Description = "Native-Born Citizen", Order = 5)] NativeBornCitizen = 4,
    [Display(Description = "Naturalized Citizen – Through a process of becoming a US Citizen", Order = 6)] NaturalizedCitizen = 5,
    [Display(Description = "Non-US Citizen PR/Green Card", Order = 1)] NonUsCitizenPrGreenCard = 0,
    [Display(Description = "Non-US Citizen Temporary Resident/Visas", Order = 2)] NonUsCitizenTemporaryResidentVisas = 1,
    [Display(Description = "Asylum/Refugee - Citizenship of their native country", Order = 3)] AsylumRefugee = 2,
    [Display(Description = "Undocumented Resident", Order = 4)] UndocumentedResident = 3,
}
