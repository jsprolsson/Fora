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
        [HttpPost("changepassword")]
        public async Task<ActionResult> ChangePassword([FromBody] UserChangePasswordDto userChangePassword)
        {
            await _userService.ChangePassword(userChangePassword);
            return Ok();
        }
        [HttpDelete("{username}")]
        public async Task<ActionResult> DeleteUser([FromRoute] string username)
        {
            await _userService.DeleteUser(username);
            return Ok();
        }
        [HttpPost("deactivate")]
        public async Task<ActionResult> DeactivateUser([FromBody] string username)
        {
            await _userService.DeactivateUser(username);
            return Ok();
        }
        [HttpPost("addrole")]
        public async Task<ActionResult> AddRole([FromBody] UserRoleDto userRole)
        {
            await _userService.AddRole(userRole);
            return Ok();
        }
        [HttpPost("removerole")]
        public async Task<ActionResult> RemoveRole([FromBody] UserRoleDto userRole)
        {
            await _userService.RemoveRole(userRole);
            return Ok();
        }
    }
}
