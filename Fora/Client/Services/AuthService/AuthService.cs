
using Fora.Client.Services.UserInterestService;
using System.Security.Claims;

namespace Fora.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        private readonly IUserInterestService _userInterestService;

        public AuthService(AuthenticationStateProvider authStateProvider, HttpClient http, ILocalStorageService localStorage, IUserInterestService userInterestService)
        {
            _authStateProvider = authStateProvider ?? throw new ArgumentNullException(nameof(authStateProvider));
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
            _userInterestService = userInterestService ?? throw new ArgumentNullException(nameof(userInterestService));
        }

        public async Task<string> GetToken()
        {
            var token = await _localStorage.GetItemAsStringAsync("token");
            return token.Replace("\"", "");
        }

        public async Task<bool> Login(UserLoginDto userLogin)
        {
            var result = await _http.PostAsJsonAsync("api/authentication/login", userLogin);
            var token = await result.Content.ReadAsStringAsync();
            await _localStorage.SetItemAsync("token", token);
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            return true;
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
            var signedIn = await Login(userLogin);
            if (signedIn)
            {
                foreach (var interest in userRegister.UserInterestIds)
                {
                    await _userInterestService.CreateUserInterest(interest);
                }
            }
        }

        public async Task<int> GetUserId()
        {
            return await _http.GetFromJsonAsync<int>("/api/authentication/userid");
        }
        public async Task<UserAuth> GetUser()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var userClaims = authState.User.Claims.ToList();
            var userRolesArray = userClaims.Where(c => c.Type == ClaimTypes.Role).Select(r => r.Value).ToArray();

            if (userClaims != null)
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

        public async Task<bool> IsAdmin()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var userClaims = authState.User.Claims.ToList();
            var userRoles = userClaims.Where(c => c.Type == ClaimTypes.Role).Select(r => r.Value).ToArray();

            if (userClaims != null)
            {
                if (userRoles[0].Contains("Admin")) return true;
            }
            return false;
        }
    }
}
