namespace Fora.Server.Services.MessageService
{
    public interface IMessageService
    {
        Task<List<MessageModel>> GetMessages(int threadId);
        Task<MessageModel> CreateMessage(MessageCreateDto messageToCreate);
        Task UpdateMessage(MessageUpdateDto messageToUpdate);
        Task DeleteMessage(int messageId);
    }
}
