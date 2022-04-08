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
        [HttpGet("interests")]
        public async Task<ActionResult> GetUserInterests()
        {
            var userInterests = await _userService.GetUserInterests();
            return Ok(userInterests);
        }
        [HttpPost("addUserInterest")]
        public async Task<ActionResult> AddUserInterest(int foraUserId, int interestId)
        {
            await _userService.AddUserInterest(foraUserId, interestId);
            return Ok();
        }
        [HttpDelete("userInterest")]
        public async Task<ActionResult> RemoveUserInterest(int interestId)
        {
            await _userService.RemoveUserInterest(interestId);
            return Ok();
        }
        [HttpPost("ban")]
        public async Task<ActionResult> BanUser(string userId)
        {
            await _userService.BanUser(userId);
            return Ok();
        }
        [HttpPost("unBan")]
        public async Task<ActionResult> UnBanUser(string userId)
        {
            await _userService.UnBanUser(userId);
            return Ok();
        }
    }
}
