namespace Fora.Client.Services.InterestService
{
    public interface IInterestService
    {
        List<InterestModel> Interests { get; set; }
        Task GetInterests();
        Task<List<InterestModel>> GetUserCreatedInterests(int userId);
        Task CreateInterest(InterestCreateDto interest);
        Task DeleteInterest(InterestDeleteDto interest);
        Task UpdateInterest(InterestUpdateDto interest);
    }
}
