using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Responses
{
    public class VisitResponse
    {
        public string Id { get; set; }
        public string? CaseId { get; set; }
        public VisitStatusEnum Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public string? Description { get; set; }
        public CaseResponse? Case { get; set; } = new();
        public UserResponse? User { get; set; } = new();
        public virtual ICollection<TaskResponse> Tasks { get; set; } = new List<TaskResponse>();


    }

}
