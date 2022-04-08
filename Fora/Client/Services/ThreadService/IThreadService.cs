namespace Fora.Client.Services.ThreadService
{
    public interface IThreadService
    {
        Task CreateThread(ThreadCreateDto threadToCreate);
        Task UpdateThread(ThreadUpdateDto threadToUpdate);

        Task DeleteThread(ThreadDeleteDto threadToDelete);
    }
}
