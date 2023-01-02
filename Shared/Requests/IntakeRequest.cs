using FluentValidation;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;
using WRMC.Infrastructure.Localization;

namespace WRMC.Core.Shared.Requests
{
    public class IntakeRequest
    {
        public string? VisitId { get; set; }
        public string? TaskId { get; set; }
        public bool IsComplete { get; set; } = false;

    }







}
