namespace Fora.Client.Services.ThreadService
{
    public interface IThreadService
    {
        Task CreateThread(ThreadCreateDto thread);
        Task UpdateThread(ThreadUpdateDto threadToUpdate);
    }
}
