namespace Fora.Server.Services.InterestService
{
    public interface IInterestService
    {
        Task<InterestModel> CreateInterest(InterestModel interest);
        Task<List<InterestModel>> GetInterests();
        Task<InterestModel> GetInterest(int interestId);
        Task UpdateInterest(InterestDto interest);
        Task DeleteInterest(int interestId);
    }
}
