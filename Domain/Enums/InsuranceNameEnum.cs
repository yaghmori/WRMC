using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum InsuranceNameEnum : short
{
    [Display(Description = "Medicaid – Full Coverage", Order = 1)] MedicaidFullCoverage = 0,
    [Display(Description = "Emergency Medicaid", Order = 2)] EmergencyMedicaid = 1,
    [Display(Description = "Anthem - Blue Cross/Blue Shield", Order = 3)] AnthemBlueCrossBlueShield = 2,
    [Display(Description = "Aetna", Order = 4)] Aetna = 3,
    [Display(Description = "Cigna", Order = 5)] Cigna = 4,
    [Display(Description = "Compass Rose Health Plan", Order = 6)] CompassRoseHealthPlan = 5,
    [Display(Description = "Hometown Health Plan", Order = 7)] HometownHealthPlan = 6,
    [Display(Description = "Prominence health Plan", Order = 8)] ProminenceHealthPlan = 7,
    [Display(Description = "Sierra Health and Life", Order = 9)] SierraHealthAndLife = 8,
    [Display(Description = "Health Plan of Nevada (HPN) - Product of Medicaid", Order = 10)] HealthPlanOfNevada = 9,
    [Display(Description = "United Health Care Group", Order = 11)] UnitedHealthCareGroup = 10,
    [Display(Description = "Humana", Order = 12)] Humana = 11,
    [Display(Description = "Culinary", Order = 13)] Culinary = 12,
    [Display(Description = "Amerigroup Nevada – Product of Medicaid", Order = 14)] AmerigroupNevada = 13,
    [Display(Description = "I don't know", Order = 15)] IDontKnow = 14,
    [Display(Description = "Other", Order = 1000)] Other = 1000,
}
