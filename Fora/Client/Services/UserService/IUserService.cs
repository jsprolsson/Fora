namespace Fora.Client.Services.UserService
{
    public interface IUserService
    {
        Task BanUser(string username);
        Task RemoveBan(string username);
        Task ChangePassword(UserChangePasswordDto userChangePassword);
        Task DeleteUser(string username);
    }
}
