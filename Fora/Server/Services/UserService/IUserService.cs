namespace Fora.Server.Services.UserService
{
    public interface IUserService
    {

        Task AddUserInterest(int foraUserId, int interestId);
        Task RemoveUserInterest(int interestId);
        Task<List<InterestModel>> GetUserInterests(int foraUserId);
        Task<List<string>> GetUserRoles(string userId);
        Task BanUser(string userId);
        Task UnBanUser(string userId);
        Task DeleteUser(string userId);
        Task UnDeleteUser(string userId);
    }
}
