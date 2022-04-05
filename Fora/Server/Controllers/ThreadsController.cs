using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fora.Server.Controllers
{
    [Route("api/interests/{interestId}/threads")]
    [ApiController]
    public class ThreadsController : ControllerBase
    {
        // GET: api/<ThreadsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ThreadsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ThreadsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ThreadsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ThreadsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
