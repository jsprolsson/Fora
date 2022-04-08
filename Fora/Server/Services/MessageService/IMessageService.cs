namespace Fora.Server.Services.MessageService
{
    public interface IMessageService
    {
        Task<List<MessageModel>> GetMessages(int threadId);
        Task<MessageModel> CreateMessage(MessageCreateDto messageToCreate);
        Task UpdateMessage(MessageDto message);
        Task DeleteMessage(int messageId);
    }
}
