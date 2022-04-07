namespace Fora.Server.Services.InterestService
{
    public interface IInterestService
    {
        Task<InterestModel> CreateInterest(InterestCreateDto interest);
        Task<List<InterestModel>> GetInterests();
        Task<InterestModel> GetInterest(int interestId);
        Task UpdateInterest(InterestModel interest);
        Task DeleteInterest(int interestId);
    }
}
