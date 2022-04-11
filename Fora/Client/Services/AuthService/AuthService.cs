
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

        public async Task<string> GetToken()
        {
            var token = await _localStorage.GetItemAsStringAsync("token");
            return token.Replace("\"", "");
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

        public async Task<int> GetUserId()
        {
            return await _http.GetFromJsonAsync<int>("/api/authentication/userid");
        }
        public async Task<UserAuth> GetUser()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var userClaims = authState.User.Claims.ToList();

            if (userClaims.Any())
            {
                UserAuth userAuth = new UserAuth
                {
                    Id = int.Parse(userClaims.Where(u => u.Type == "ForaUser").Select(u => u.Value).SingleOrDefault()),
                    Username = authState.User.Identity.Name
                };
                return userAuth;
            }
            return null;
        }
    }
}
