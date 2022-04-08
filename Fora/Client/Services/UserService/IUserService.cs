namespace Fora.Client.Services.UserService
{
    public interface IUserService
    {
        Task BanUser(string userId);
        Task UnBanUser(string userId);
    }
}
