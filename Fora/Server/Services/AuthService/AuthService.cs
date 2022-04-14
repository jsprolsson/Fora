using Fora.Server.DbContexts;
using Fora.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Fora.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _appDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserDbContext _userDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IConfiguration configuration,
            AppDbContext appDbContext, SignInManager<ApplicationUser> signInManager,
            UserDbContext userDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userDbContext = userDbContext ?? throw new ArgumentNullException(nameof(userDbContext));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }
        public int GetForaUserId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue("ForaUser"));
        }
        public async Task<string> Login(UserLoginDto userLogin)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(userLogin.Username, userLogin.Password, false, false);

            if (signInResult.Succeeded)
            {
                // Check if user is banned
                var currentUser = await _signInManager.UserManager.FindByNameAsync(userLogin.Username);
                if (!currentUser.Banned)
                {
                    // Create JWT
                    return await CreateToken(currentUser);
                }
            }
            return null;
        }

        private async Task<string> CreateToken(ApplicationUser user)
        {
            var roles = await _signInManager.UserManager.GetRolesAsync(user);
            List<Claim> claims = new List<Claim>
            {
                // Add new claims here if more user properties are needed
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("ForaUser", user.ForaUser.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            // Add all user roles
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWTSettings:SecretForKey").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["JWTSettings:Issuer"],
                _configuration["JWTSettings:Audience"],
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(6000),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task Register(UserRegisterDto userRegister)
        {
            var usernameTaken = await _signInManager.UserManager.FindByNameAsync(userRegister.Username);
            var emailTaken = await _signInManager.UserManager.FindByEmailAsync(userRegister.Email);

            if (usernameTaken == null && emailTaken == null)
            {
                // UserDb
                ApplicationUser newUser = new();
                newUser.UserName = userRegister.Username;
                newUser.Email = userRegister.Email;

                var result = await _signInManager.UserManager.CreateAsync(newUser, userRegister.Password);
                if (result.Succeeded)
                {
                    await _signInManager.UserManager.AddToRoleAsync(newUser, "User");

                    // AppDb
                    UserModel newForaUser = new UserModel
                    {
                        Username = newUser.UserName,
                    };

                    _appDbContext.Add(newForaUser);
                    var created = await _appDbContext.SaveChangesAsync();

                    if (created > 0)
                    {
                        var foraUser = await _appDbContext.Users.Where(u => u.Username == newUser.UserName).FirstOrDefaultAsync();
                        if (foraUser != null)
                        {
                            newUser.ForaUser = foraUser.Id;
                            await _userDbContext.SaveChangesAsync();
                        }
                    }
                }
            }
        }

        public async Task<string> RefreshToken()
        {
            var currentUser = _httpContextAccessor.HttpContext.User;
            var applicationUser = await _signInManager.UserManager.FindByNameAsync(currentUser.Identity.Name);
            if (applicationUser != null)
            {
                return await CreateToken(applicationUser);
            }
            return null;
        }
    }
}
