namespace Fora.Server.Services.MessageService
{
    public interface IMessageService
    {
        Task<List<MessageModel>> GetMessages(int threadId);
        Task<MessageModel> CreateMessage(MessageDTO message, int threadId);
        Task UpdateMessage(MessageDTO message);
        Task DeleteMessage(int messageId);
    }
}
