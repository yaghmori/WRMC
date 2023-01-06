using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class ChangePasswordRequest : IValidatableObject
    {

        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string NewPassword { get; set; } = default!;

        [Required]
        [Compare(nameof(NewPassword))]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Confirmation Password must be at least 8 characters long.", MinimumLength = 8)]
        public string ConfirmationPassword { get; set; } = default!;


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (CurrentPassword == "ehsanyaghmori")
            {
                results.Add(new ValidationResult("Prop1 must be larger than Prop2", new[] { nameof(CurrentPassword) }));

            }
            return results;
        }
    }
}
