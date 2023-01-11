using FluentValidation;
using System.ComponentModel.DataAnnotations;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Requests
{
    public class UserAttachmentRequest
    {
        public string UserId { get; set; }
        public virtual AttachmentTypeEnum? Type { get; set; }
        public string URL { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsDefault { get; set; } = false;
        public int? Order { get; set; }
    }
    public class UserAttachmentValidator : AbstractValidator<UserAttachmentRequest>
    {

        public UserAttachmentValidator()
        {

            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
            RuleFor(x => x.Type).NotNull().WithMessage("Type is required");
            RuleFor(x => x.URL).NotEmpty().WithMessage("URL is required");
        }

    }
}
