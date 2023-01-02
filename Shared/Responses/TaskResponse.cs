using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Responses;

public class TaskResponse
{
    public string Id { get; set; }
    public SectionResponse Section { get; set; }
    public TaskStatusEnum Status { get; set; }
    public string? UserId { get; set; }
    public string? VisitId { get; set; }
    public string? SectionId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}