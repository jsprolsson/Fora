namespace Fora.Client.Services.MessageService
{
    public interface IMessageService
    {
        Task CreateMessage(MessageCreateDto messageToCreate);
        Task<List<MessageModel>> GetMessages(int threadId);
        Task UpdateMessage(MessageUpdateDto messageToUpdate);
        Task DeleteMessage(MessageDeleteDto messageToDelete);
    }
}
