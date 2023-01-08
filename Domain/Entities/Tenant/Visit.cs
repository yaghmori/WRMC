using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities;

public class Visit : BaseEntity<Guid>
{
    [Column(Order = 1)]
    public Guid? CaseId { get; set; }
    public virtual Case? Case { get; set; }
    [Column(Order = 2)]
    public virtual VisitStatusEnum Status { get; set; }
    [Column(Order = 3)]
    public DateTime? StartDate { get; set; }
    [Column(Order = 4)]
    public DateTime? EndDate { get; set; }
    [Column(Order = 5)]
    public string? Name { get; set; }
    [Column(Order = 6)]
    public string? Comment { get; set; }
    [Column(Order = 7)]
    public string? Description { get; set; }
    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    public virtual ICollection<DemographicIntake> DemographicIntakes { get; set; } = new List<DemographicIntake>();
    public virtual ICollection<MedicalIntake> MedicalInformations { get; set; } = new List<MedicalIntake>();
}