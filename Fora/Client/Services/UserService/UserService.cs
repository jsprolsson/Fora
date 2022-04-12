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
        public async Task BanUser(string username)
        {
            var result = await _http.PostAsJsonAsync("api/user/ban", username);
        }

        public async Task RemoveBan(string username)
        {
            var result = await _http.PostAsJsonAsync("api/user/removeban", username);
        }

        public async Task ChangePassword(UserChangePasswordDto userChangePassword)
        {
            var result = await _http.PostAsJsonAsync("api/user/changepassword", userChangePassword);
        }

        public async Task DeleteUser(string username)
        {
            var result = await _http.DeleteAsync($"api/user/{username}");
            //_authService.Logout();
        }

        public async Task AddRole(UserRoleDto userRole)
        {
            var result = await _http.PostAsJsonAsync("api/user/addrole", userRole);
        }

        public async Task RemoveRole(UserRoleDto userRole)
        {
            var result = await _http.PostAsJsonAsync("api/user/removerole", userRole);
        }
    }
}
