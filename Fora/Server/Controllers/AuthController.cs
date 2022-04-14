using Fora.Server.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fora.Server.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginDto userLogin)
        {
            var token = await _authService.Login(userLogin);
            return token;
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterDto userRegister)
        {
            await _authService.Register(userRegister);
            return Ok();
        }

        [HttpGet("userid")]
        public int GetUserId()
        {
            return _authService.GetForaUserId();
        }
        [HttpGet("refreshtoken")]
        public async Task<string> RefreshToken()
        {
            return await _authService.RefreshToken();
        }
    }
}