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
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(IConfiguration configuration, SignInManager<ApplicationUser> signInManager)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        public async Task<string> Login(UserLoginDto userLogin)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(userLogin.Username, userLogin.Password, false, false);

            if (signInResult.Succeeded)
            {
                var currentUser = await _signInManager.UserManager.FindByNameAsync(userLogin.Username);
                // Create JWT
                return await CreateToken(currentUser);
            }

            // This will return Admin JWT. Change to null when signin is working
            var currentUserTemp = await _signInManager.UserManager.FindByNameAsync("ADMIN");
            return await CreateToken(currentUserTemp);
        }

        private async Task<string> CreateToken(ApplicationUser user)
        {
            var roles = await _signInManager.UserManager.GetRolesAsync(user);
            List<Claim> claims = new List<Claim>
            {
                // Add new claims here if more user properties are needed
                new Claim("username", user.UserName)
            };
            // Add all user roles
            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWTSettings:SecretForKey").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["JWTSettings:Issuer"],
                _configuration["JWTSettings:Audience"],
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task Register(UserRegisterDto userRegister)
        {
            ApplicationUser newUser = new();

            newUser.UserName = userRegister.Username;
            newUser.Email = userRegister.Email;

            var result = await _signInManager.UserManager.CreateAsync(newUser, userRegister.Password);

        }
    }
}
