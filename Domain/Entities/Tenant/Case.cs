using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities;

public class Case : BaseEntity<Guid>
{
    public Guid? UserId { get; set; }
    public string? CaseNo { get; set; }
    public virtual CaseStatusEnum Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Description { get; set; }
    public virtual User? User { get; set; }
    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}