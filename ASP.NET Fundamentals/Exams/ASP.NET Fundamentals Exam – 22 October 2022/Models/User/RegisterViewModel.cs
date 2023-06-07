using System.ComponentModel.DataAnnotations;
using static Library.Constants.Constants.LoginConstants;

namespace Library.Models.User
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(EmailNameMaxLength, MinimumLength = EmailMinLength)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(PasswordNameMaxLength, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
