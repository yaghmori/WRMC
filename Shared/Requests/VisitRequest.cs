using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Requests;

public class VisitRequest
{

    public string? CaseId { get; set; }
    public VisitStatusEnum Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Name { get; set; }
    public string? Comment { get; set; }
    public string? Description { get; set; }
    
}