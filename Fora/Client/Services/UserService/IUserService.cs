namespace Fora.Client.Services.UserService
{
    public interface IUserService
    {
        Task AddRole(UserRoleDto userRole);
        Task RemoveRole(UserRoleDto userRole);
        Task BanUser(string username);
        Task RemoveBan(string username);
        Task ChangePassword(UserChangePasswordDto userChangePassword);
        Task DeleteUser(string username);
        Task DeactivateUser(string username);
    }
}
