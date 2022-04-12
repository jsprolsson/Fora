namespace Fora.Server.Services.UserService
{
    public interface IUserService
    {
        Task AddRole(UserRoleDto userRole);
        Task RemoveRole(UserRoleDto userRole);
        Task BanUser(string userId);
        Task RemoveBan(string userId);
        Task DeleteUser(string username);
        Task UnDeleteUser(string userId);
        Task ChangePassword(UserChangePasswordDto userChangePassword);
    }
}
