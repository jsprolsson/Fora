using Fora.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
                // create JWT
                string token = CreateToken(userLogin);
            }

            // Change to null when signin is working
            return CreateToken(userLogin);
        }

        private string CreateToken(UserLoginDto userLogin)
        {
            List<Claim> claims = new List<Claim>
            {
                // Add new claims here if more user properties are needed
                new Claim(ClaimTypes.Name, userLogin.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Authentication:SecretForKey").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
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
