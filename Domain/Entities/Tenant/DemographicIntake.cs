using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class DemographicIntake : BaseEntity<Guid>
    {

        public Guid? VisitId { get; set; }
        public Guid? TaskId { get; set; }
        public bool IsComplete { get; set; } = false;
        public int? RegionId { get; set; }
        public bool? InSchool { get; set; }
        public LastGradeEnum? LastGrade { get; set; }
        public string? SchoolName { get; set; }
        public MaritalEnum? MaritalStatus { get; set; }
        public bool? IsUSCitizen { get; set; }
        public ImmigrationStatusEnum? ImmigrationStatus { get; set; }
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
        public string? FinancialSupport { get; set; }
        public bool? AffordPrenatal { get; set; }
        public bool? UndueBurden { get; set; }
        public bool? ConduciveRaising { get; set; }
        public bool? HidePregnancy { get; set; }

        public virtual Visit? Visit { get; set; }
        public virtual Tasks? Task { get; set; }
        public virtual Region? Region { get; set; }

    }
}
