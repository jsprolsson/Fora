namespace Fora.Server.Services.MessageService
{
    public class MessageService : IMessageService
    {
        private readonly AppDbContext _appDbContext;

        public MessageService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<MessageModel> CreateMessage(MessageCreateDto messageToCreate)
        {
            //Use DTO object to not clutter json object in swagger with all the relations.
            var messageModel = new MessageModel()
            {
                Message = messageToCreate.Message,
                ThreadId = messageToCreate.ThreadId,
                UserId = messageToCreate.UserId
            };
            _appDbContext.Add(messageModel);
            await _appDbContext.SaveChangesAsync();
            return messageModel;
        }

        public async Task<List<MessageModel>> GetMessages(int threadId)
        {
            //Gets messages that are in the thread.
            return await _appDbContext.Messages.Where(m => m.ThreadId == threadId).OrderBy(m => m.Id).ToListAsync();
        }


        public async Task UpdateMessage(MessageDto message)
        {
            //Find message to update
            var messageEntity = await _appDbContext.Messages.FirstOrDefaultAsync(m => m.Id == message.Id);
            if (messageEntity is not null)
            {
                message.DateTimeCreated = messageEntity.DateTimeCreated;
                message.DateTimeModified = DateTime.Now;
                message.Deleted = false;
                _appDbContext.Entry(messageEntity).CurrentValues.SetValues(message);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteMessage(int messageId)
        {
            //Archives the message and uses bool to show as a deleted message.

            var messageToDelete = await _appDbContext.Messages.FirstOrDefaultAsync(m => m.Id == messageId);
            messageToDelete.Deleted = true;
            _appDbContext.Update(messageToDelete);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
