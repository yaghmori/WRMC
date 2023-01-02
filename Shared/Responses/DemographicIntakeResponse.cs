using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Responses
{
    public class DemographicIntakeResponse
    {
        public string Id { get; set; }=string.Empty;
        public string? VisitId { get; set; }
        public string? TaskId { get; set; }
        public bool? InSchool { get; set; } 
        public LastGradeEnum? LastGrade { get; set; } 
        public string? SchoolName { get; set; } 
        public MaritalEnum? MaritalStatus { get; set; } 
        public bool? IsUSCitizen { get; set; } 
        public ImmigrationStatusEnum? ImmigrationStatus { get; set; } 
        public int? RegionId { get; set; } 
        public RegionResponse Region { get; set; } 
        public GenderEnum? Gender { get; set; } 
        public LivingEnum? LivingArrangement { get; set; } 
        public EmploymentEnum? Employment { get; set; } 
        public string? Employer { get; set; } 
        public string? Occupation { get; set; } 
        public IncomeEnum? Income { get; set; } 
        public bool? CombinedIncome { get; set; } 
        public bool? HaveInsurance { get; set; } 
        public InsuranceNameEnum? InsuranceName { get; set; } 
        public string? MedicaidNo { get; set; } 
        public bool? NeedInsurance { get; set; } 
        public short? NumberOfTaxReturn { get; set; } 
        public short? NumberOfHousehold { get; set; } 
        public bool? Disabled { get; set; }
        public bool? IsComplete { get; set; } 
        public string? FinancialSupport { get; set; } 
        public bool? AffordPrenatal { get; set; } 
        public bool? UndueBurden { get; set; } 
        public bool? ConduciveRaising { get; set; } 
        public bool? HidePregnancy { get; set; } 
    }
}
