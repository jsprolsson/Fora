namespace Fora.Client.Services.UserService
{
    public interface IUserService
    {
        Task<List<InterestModel>> GetUserInterests();
        Task BanUser(string userId);
        Task UnBanUser(string userId);
    }
}
