using Fora.Server.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fora.Server.Controllers
{
    [Route("api/user"), Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        [HttpPost("ban")]
        public async Task<ActionResult> BanUser([FromBody] string username)
        {
            await _userService.BanUser(username);
            return Ok();
        }
        [HttpPost("removeban")]
        public async Task<ActionResult> RemoveBan([FromBody] string username)
        {
            await _userService.RemoveBan(username);
            return Ok();
        }
    }
}
