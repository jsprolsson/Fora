namespace Fora.Server.Services.UserService
{
    public interface IUserService
    {
        Task AddRole(UserRoleDto userRole);
        Task RemoveRole(UserRoleDto userRole);
        Task BanUser(string userId);
        Task RemoveBan(string userId);
        Task DeactivateUser(string username);
        Task DeleteUser(string username);
        Task UnDeleteUser(string userId);
        Task ChangePassword(UserChangePasswordDto userChangePassword);
        Task<List<UserRoleDto>> GetAllUsers();
    }
}
