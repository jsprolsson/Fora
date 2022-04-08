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
        public async Task Put(MessageUpdateDto messageToUpdate)
        {
            await _messageService.UpdateMessage(messageToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            //Create Get method for finding one message for validation that message exists.. Then if exists, pass to DeleteMessage-func.
            await _messageService.DeleteMessage(id);
        }
    }
}
