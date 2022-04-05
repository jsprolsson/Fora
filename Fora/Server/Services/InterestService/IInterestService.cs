namespace Fora.Server.Services.InterestService
{
    public interface IInterestService
    {
        Task<InterestModel> CreateInterest(InterestModel interest);
        Task<List<InterestModel>> GetInterests();
        Task<InterestModel> GetInterest(int interestId);
        Task<InterestModel> UpdateInterest(InterestModel interest);
        Task DeleteInterest(int interestId);
    }
}
