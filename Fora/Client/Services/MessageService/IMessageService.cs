namespace Fora.Client.Services.MessageService
{
    public interface IMessageService
    {
        List<MessageModel> Messages { get; set; }
        Task CreateMessage(MessageCreateDto messageToCreate);
        Task GetMessages(int threadId);
        Task UpdateMessage(MessageUpdateDto messageToUpdate);
        Task DeleteMessage(MessageDeleteDto messageToDelete);
    }
}
