namespace Fora.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
        }
        public async Task BanUser(string userId)
        {
            await _http.PostAsJsonAsync("api/user/ban", userId);
        }

        public async Task UnBanUser(string userId)
        {
            await _http.PostAsJsonAsync("api/user/unban", userId);
        }
    }
}
