namespace Fora.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<string> Login(UserLoginDto userLogin);
        Task Register(UserRegisterDto userRegister);
    }
}
