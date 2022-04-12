namespace Fora.Server.Services.UserService
{
    public interface IUserService
    {
        Task<List<string>> GetUserRoles(string userId);
        Task BanUser(string userId);
        Task RemoveBan(string userId);
        Task DeleteUser(string username);
        Task UnDeleteUser(string userId);
        Task ChangePassword(UserChangePasswordDto userChangePassword);
    }
}
