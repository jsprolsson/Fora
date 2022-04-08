
namespace Fora.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;

        public AuthService(AuthenticationStateProvider authStateProvider, HttpClient http, ILocalStorageService localStorage)
        {
            _authStateProvider = authStateProvider ?? throw new ArgumentNullException(nameof(authStateProvider));
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
        }
        public async Task Login(UserLoginDto userLogin)
        {
            var result = await _http.PostAsJsonAsync("api/authentication/login", userLogin);
            var token = await result.Content.ReadAsStringAsync();
            await _localStorage.SetItemAsync("token", token);
            await _authStateProvider.GetAuthenticationStateAsync();
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            await _authStateProvider.GetAuthenticationStateAsync();
        }

        public async Task Register(UserRegisterDto userRegister)
        {
            await _http.PostAsJsonAsync("api/authentication/register", userRegister);
            UserLoginDto userLogin = new UserLoginDto
            {
                Username = userRegister.Username,
                Password = userRegister.Password
            };
            await Login(userLogin);
        }
    }
}
