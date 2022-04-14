namespace Fora.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<string> GetToken();
        Task<bool> Login(UserLoginDto userLogin);
        Task Logout();
        Task Register(UserRegisterDto userRegister);
        Task<int> GetUserId();
        Task<UserAuth> GetUser();
        Task<bool> IsAdmin();
        Task<bool> IsDeleted();
        Task RefreshToken();
    }
}
