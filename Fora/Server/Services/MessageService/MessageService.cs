namespace Fora.Server.Services.MessageService
{
    public class MessageService : IMessageService
    {
        private readonly AppDbContext _appDbContext;

        public MessageService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<MessageModel>> GetMessages(int threadId)
        {
            return await _appDbContext.Messages.Where(m => m.ThreadId == threadId).ToListAsync();
        }
    }
}
