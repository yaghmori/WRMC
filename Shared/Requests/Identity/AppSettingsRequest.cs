using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class AppSettingsRequest
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool? IsReadOnly { get; set; }
    }

    public class AppSettingsValidator : AbstractValidator<AppSettingsRequest>
    {

        public AppSettingsValidator()
        {

            RuleFor(x => x.Key).NotEmpty().WithMessage("Key is required");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Value is required");
        }

    }
}
