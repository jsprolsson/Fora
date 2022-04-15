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
            return await _appDbContext.Messages.Where(m => m.ThreadId == threadId).Include(m => m.User).OrderBy(m => m.Id).ToListAsync();
        }


        public async Task UpdateMessage(MessageUpdateDto messageToUpdate)
        {
            var messageEntity = await _appDbContext.Messages.FirstOrDefaultAsync(m => m.Id == messageToUpdate.Id);
            if (messageEntity is not null)
            {
                MessageModel newMessage = new()
                {
                    Id = messageToUpdate.Id,
                    Message = messageToUpdate.Message,
                    DateTimeCreated = messageEntity.DateTimeCreated,
                    DateTimeModified = DateTime.Now,
                    ThreadId = messageToUpdate.ThreadId,
                    UserId = messageToUpdate.UserId,
                    Deleted = false
                };
                
                _appDbContext.Entry(messageEntity).CurrentValues.SetValues(newMessage);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteMessage(int id)
        {
            //Archives the message and uses bool to show as a deleted message.

            var messageToDelete = await _appDbContext.Messages.FirstOrDefaultAsync(m => m.Id == id);
            messageToDelete.Deleted = true;
            messageToDelete.DateTimeModified = DateTime.Now;
            _appDbContext.Update(messageToDelete);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
