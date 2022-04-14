namespace Fora.Server.Services.AuthService
{
    public interface IAuthService
    {
        int GetForaUserId();
        Task<string> Login(UserLoginDto userLogin);
        Task Register(UserRegisterDto userRegister);
        Task<string> RefreshToken();
    }
}
