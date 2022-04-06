using System.ComponentModel.DataAnnotations;

namespace Fora.Shared.DTO
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(20, ErrorMessage = "Username is too long")]
        [MinLength(3, ErrorMessage = "Username is too short")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
        //[Required(ErrorMessage = "Verify password is required")]
        //[Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
        //public string VerifiedPassword { get; set; } = string.Empty;
    }
}
