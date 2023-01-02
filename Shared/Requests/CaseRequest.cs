using FluentValidation;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Requests;

public class CaseRequest
{
    public string? UserId { get; set; }
    public string? CaseNo { get; set; }
    public CaseStatusEnum Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Description { get; set; }
}
public class CaseRequestValidator : AbstractValidator<CaseRequest>
{
    public CaseRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().NotNull();
        RuleFor(x => x.CaseNo).NotEmpty().NotNull();
    }

}