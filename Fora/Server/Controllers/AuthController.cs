using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fora.Server.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("authenticate")]
        public async Task<ActionResult<string>> Authenticate(UserLoginDto request)
        {
            string token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiVG9ueSBTdGFyayIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6Iklyb24gTWFuIiwiZXhwIjozMTY4NTQwMDAwfQ.IbVQa1lNYYOzwso69xYfsMOHnQfO3VLvVqV2SOXS7sTtyyZ8DEf5jmmwz2FGLJJvZnQKZuieHnmHkg7CGkDbvA";
            return token;
        }
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(UserRegisterDto request)
        {

        }
    }
}