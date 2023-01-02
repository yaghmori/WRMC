using FluentValidation;

namespace WRMC.Core.Shared.Requests;

public class CaseRequestValidator : AbstractValidator<CaseRequest>
{
    public CaseRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().NotNull();
        RuleFor(x => x.CaseNo).NotEmpty().NotNull();
    }

}
