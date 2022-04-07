namespace Fora.Client.Services.InterestService
{
    public interface IInterestService
    {
        List<InterestModel> Interests { get; set; }
        Task GetInterests();
        Task CreateInterest(InterestCreateDto interest);
        Task DeleteInterest(InterestDeleteDto interest);
        Task UpdateInterest(InterestUpdateDto interest);
    }
}
