using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class DemographicIntake : BaseEntity<Guid>
    {
        [Column(Order =1)]
        public Guid? VisitId { get; set; }
        [Column(Order = 2)]
        public Guid? TaskId { get; set; }
        [Column(Order = 3)]
        public int? RegionId { get; set; }
        [Column(Order = 4)]
        public bool? InSchool { get; set; }
        [Column(Order = 5)]
        public LastGradeEnum? LastGrade { get; set; }
        [Column(Order = 6)]
        public string? SchoolName { get; set; }
        [Column(Order = 7)]
        public MaritalEnum? MaritalStatus { get; set; }
        [Column(Order = 8)]
        public bool? IsUSCitizen { get; set; }
        [Column(Order = 9)]
        public ImmigrationStatusEnum? ImmigrationStatus { get; set; }
        [Column(Order = 10)]
        public LivingEnum? LivingArrangement { get; set; }
        [Column(Order = 11)]
        public EmploymentEnum? Employment { get; set; }
        [Column(Order = 12)]
        public string? Employer { get; set; }
        [Column(Order = 13)]
        public string? Occupation { get; set; }
        [Column(Order = 14)]
        public IncomeEnum? Income { get; set; }
        [Column(Order = 15)]
        public bool? CombinedIncome { get; set; }
        [Column(Order = 16)]
        public bool? HaveInsurance { get; set; }
        [Column(Order = 17)]
        public InsuranceNameEnum? InsuranceName { get; set; }
        [Column(Order = 18)]
        public string? MedicaidNo { get; set; }
        [Column(Order = 19)]
        public bool? NeedInsurance { get; set; }
        [Column(Order = 20)]
        public short? NumberOfTaxReturn { get; set; }
        [Column(Order = 21)]
        public short? NumberOfHousehold { get; set; }
        [Column(Order = 22)]
        public bool? Disabled { get; set; }
        [Column(Order = 23)]
        public string? FinancialSupport { get; set; }
        [Column(Order = 24)]
        public bool? AffordPrenatal { get; set; }
        [Column(Order = 25)]
        public bool? UndueBurden { get; set; }
        [Column(Order = 26)]
        public bool? ConduciveRaising { get; set; }
        [Column(Order = 27)]
        public bool? HidePregnancy { get; set; }
        [Column(Order = 28)]
        public bool IsComplete { get; set; } = false;

        public virtual Region? Region { get; set; } 
        public virtual Visit? Visit { get; set; }
        public virtual Tasks? Task { get; set; }

    }
}
