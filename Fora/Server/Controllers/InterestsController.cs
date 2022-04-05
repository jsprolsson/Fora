using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fora.Server.Controllers
{
    [Route("api/interests")]
    [ApiController]
    public class InterestsController : ControllerBase
    {
        // GET: api/<InterestsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InterestsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InterestsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InterestsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InterestsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
