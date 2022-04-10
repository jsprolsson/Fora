using Fora.Server.Services.UserInterestService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fora.Server.Controllers
{
    [Route("api/userInterests"), Authorize]
    [ApiController]
    public class UserInterestsController : ControllerBase
    {
        private readonly IUserInterestService _userInterestService;

        public UserInterestsController(IUserInterestService userInterestService)
        {
            _userInterestService = userInterestService ?? throw new ArgumentNullException(nameof(userInterestService));
        }
        // GET: api/<UserInterestsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var userInterests = await _userInterestService.GetUserInterests();
            return Ok(userInterests);
        }

        // GET api/<UserInterestsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UserInterestsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] int interestId)
        {
            await _userInterestService.CreateUserInterest(interestId);
            return Ok();
        }

        // PUT api/<UserInterestsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<UserInterestsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userInterestService.DeleteUserInterest(id);
            return Ok();
        }
    }
}
