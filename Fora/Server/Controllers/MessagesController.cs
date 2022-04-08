using Fora.Server.Services.MessageService;
using Microsoft.AspNetCore.Mvc;


namespace Fora.Server.Controllers
{
    [Route("api/threads/{threadId}/messages")]
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


        [HttpPost]
        public async Task<MessageModel> Post(MessageCreateDto message)
        {
            var createdMessage = await _messageService.CreateMessage(message);
            return createdMessage;
        }

        [HttpPut]
        public async Task Put(MessageDto message, int threadId)
        {
            message.ThreadId = threadId;
            await _messageService.UpdateMessage(message);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _messageService.DeleteMessage(id);
        }
    }
}
