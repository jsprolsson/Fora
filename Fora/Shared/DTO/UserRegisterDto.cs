
namespace Fora.Shared.DTO
{
    public class UserRegisterDto
    {

        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        //[Required(ErrorMessage = "Verify password is required")]
        //[Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
        //public string VerifiedPassword { get; set; } = string.Empty;
        public List<int> UserInterestIds { get; set; } = new();
    }
}
