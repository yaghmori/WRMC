using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Requests;

public class TaskRequest
{

    public string VisitId { get; set; }
    public string? SectionId { get; set; }
    public string? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public virtual TaskStatusEnum Status { get; set; } = TaskStatusEnum.NotCompleted;

}