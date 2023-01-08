using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities;

public class Tasks : BaseEntity<Guid>
{
    [Column(Order = 1)]
    public Guid VisitId { get; set; }
    [Column(Order = 2)]
    public string? UserId { get; set; }
    [Column(Order = 3)]
    public Guid SectionId { get; set; }
    [Column(Order = 4)]
    public DateTime? StartDate { get; set; }
    [Column(Order = 5)]
    public DateTime? EndDate { get; set; }
    [Column(Order = 6)]
    public virtual TaskStatusEnum Status { get; set; } = TaskStatusEnum.NotCompleted;
    
    
    public virtual Visit Visit { get; set; }
    public virtual Section Section { get; set; }
    public virtual ICollection<DemographicIntake> DemographicIntakes { get; set; } = new List<DemographicIntake>();
    public virtual ICollection<MedicalIntake> MedicalIntakes { get; set; } = new List<MedicalIntake>();


}