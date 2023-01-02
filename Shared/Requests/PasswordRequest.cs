using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class PasswordRequest

    {

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string Password { get; set; } = default!;

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Password Confirmation must be at least 8 characters long.", MinimumLength = 8)]
        public string PasswordConfirmation { get; set; } = default!;

    }
}
