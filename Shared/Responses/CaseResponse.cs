using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Responses
{
    public class CaseResponse
    {
        public string Id { get; set; }
        public string? UserId { get; set; }
        public string? CaseNo { get; set; }
        public CaseStatusEnum Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public UserResponse? User { get; set; } = new();

        public virtual ICollection<VisitResponse> Visits { get; set; } = new List<VisitResponse>();


    }

}
