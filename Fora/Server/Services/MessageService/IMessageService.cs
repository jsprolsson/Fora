namespace Fora.Server.Services.MessageService
{
    public interface IMessageService
    {
        Task<List<MessageModel>> GetMessages(int threadId);
        Task<MessageModel> CreateMessage(MessageDto message, int threadId);
        Task UpdateMessage(MessageDto message);
        Task DeleteMessage(int messageId);
    }
}
