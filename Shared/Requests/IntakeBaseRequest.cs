using FluentValidation;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;
using WRMC.Infrastructure.Localization;

namespace WRMC.Core.Shared.Requests
{
    public class IntakeBaseRequest
    {
        public string? VisitId { get; set; }
        public string? TaskId { get; set; }
        public bool IsComplete { get; set; } = false;

    }

    public class IntakeBaseValidator : AbstractValidator<IntakeBaseRequest>
    {
        public IntakeBaseValidator()
        { 
            RuleFor(x => x.VisitId).NotEmpty().WithMessage("Please specify visit id"); //TODO : Localization
            RuleFor(x => x.TaskId).NotEmpty().WithMessage("Please specify task id");
        }
    }





}
