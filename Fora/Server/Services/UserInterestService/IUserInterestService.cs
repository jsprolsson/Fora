namespace Fora.Server.Services.UserInterestService
{
    public interface IUserInterestService
    {
        Task CreateUserInterest(int interestId);
        Task<List<InterestModel>> GetUserInterests();
        Task DeleteUserInterest(int interestId);
    }
}
