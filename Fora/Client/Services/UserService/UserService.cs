using Fora.Client.Services.AuthService;
using System.Net.Http.Headers;

namespace Fora.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly IAuthService _authService;
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;

        public UserService(AuthenticationStateProvider authStateProvider, IAuthService authService, HttpClient http, ILocalStorageService localStorage)
        {
            _authStateProvider = authStateProvider ?? throw new ArgumentNullException(nameof(authStateProvider));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
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
