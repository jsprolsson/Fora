namespace Fora.Server.Services.MessageService
{
    public interface IMessageService
    {
        Task<List<MessageModel>> GetMessages(int threadId);
    }
}
