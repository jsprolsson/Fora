namespace Fora.Client.Services.ThreadService
{
    public interface IThreadService
    {
        Task CreateThread(ThreadCreateDto thread);
    }
}
