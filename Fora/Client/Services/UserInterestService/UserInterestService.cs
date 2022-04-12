namespace Fora.Client.Services.UserInterestService
{
    public class UserInterestService : IUserInterestService
    {
        private readonly HttpClient _http;

        public UserInterestService(HttpClient http)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
        }
        public async Task CreateUserInterest(int interestId)
        {
            var result = await _http.PostAsJsonAsync("api/userinterests", interestId);
        }

        public Task DeleteUserInterest(int interestId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InterestModel>> GetUserInterests()
        {
            var result = await _http.GetFromJsonAsync<List<InterestModel>>("api/userinterests");
            return result;
        }
    }
}
