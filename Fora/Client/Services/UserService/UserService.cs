using System.Net.Http.Headers;

namespace Fora.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;

        public UserService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
        }
        public async Task BanUser(string userId)
        {
            await _http.PostAsJsonAsync("api/user/ban", userId);
        }

        public async Task<List<InterestModel>> GetUserInterests()
        {
            var token = await _localStorage.GetItemAsStringAsync("token");
            token = token.Replace("\"", "");
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await _http.GetFromJsonAsync<List<InterestModel>>("api/user/interests");
        }

        public async Task UnBanUser(string userId)
        {
            await _http.PostAsJsonAsync("api/user/unban", userId);
        }
    }
}
