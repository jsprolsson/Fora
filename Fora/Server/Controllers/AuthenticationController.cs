using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fora.Server.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate()
        {
            return null;
        }
    }
}