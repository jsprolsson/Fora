using Fora.Server.Services.MessageService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fora.Server.Controllers
{
    [Route("api/interests/{interestId}/threads/{threadId}/messages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService MessageService)
        {
            _messageService = MessageService;
        }
        
        [HttpGet]
        public async Task<List<MessageModel>> Get(int threadId)
        {
            return await _messageService.GetMessages(threadId);
        }

        //// GET api/<MessagesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<MessagesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MessagesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MessagesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
