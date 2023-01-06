using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class ResetPasswordRequest

    {
        [Required]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]

        public string Password { get; set; } = default!;

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Confirmation Password must be at least 8 characters long.", MinimumLength = 8)]

        public string ConfirmationPassword { get; set; } = default!;

        [Required]
        public string Token { get; set; } = default!;


    }
}
