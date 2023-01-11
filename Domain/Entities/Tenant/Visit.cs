using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities;

public class Visit : BaseEntity<Guid>
{
    public Guid? CaseId { get; set; }
    public virtual VisitStatusEnum Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Name { get; set; }
    public string? Comment { get; set; }
    public string? Description { get; set; }

    public virtual Case? Case { get; set; }
    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    public virtual ICollection<DemographicIntake> DemographicIntakes { get; set; } = new List<DemographicIntake>();
    public virtual ICollection<MedicalIntake> MedicalInformations { get; set; } = new List<MedicalIntake>();
}