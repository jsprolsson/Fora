namespace Fora.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task Login(UserLoginDto userLogin);
        Task Logout();
        Task Register(UserRegisterDto userRegister);
    }
}
