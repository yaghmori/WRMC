using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities;

public class Case : BaseEntity<Guid>
{
    [Column(Order = 1)]
    public string? UserId { get; set; }
    [Column(Order = 2)]
    public string? CaseNo { get; set; }
    [Column(Order = 4)]
    public virtual CaseStatusEnum Status { get; set; }
    [Column(Order = 5)]
    public DateTime? StartDate { get; set; }
    [Column(Order = 6)]
    public DateTime? EndDate { get; set; }
    public string? Description { get; set; }

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}