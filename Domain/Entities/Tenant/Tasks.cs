using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities;

public class Tasks : BaseEntity<Guid>
{
    public Guid VisitId { get; set; }
    public Guid? UserId { get; set; }
    public Guid SectionId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public virtual TaskStatusEnum Status { get; set; } = TaskStatusEnum.NotCompleted;
    
    
    public virtual Visit Visit { get; set; }
    public virtual User? User { get; set; }
    public virtual Section? Section { get; set; }

    public virtual ICollection<DemographicIntake> DemographicIntakes { get; set; } = new List<DemographicIntake>();
    public virtual ICollection<MedicalIntake> MedicalIntakes { get; set; } = new List<MedicalIntake>();


}