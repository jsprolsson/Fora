namespace Fora.Server.Services.UserService
{
    public interface IUserService
    {
        Task<List<string>> GetUserRoles(string userId);
        Task BanUser(string userId);
        Task UnBanUser(string userId);
        Task DeleteUser(string userId);
        Task UnDeleteUser(string userId);
    }
}
