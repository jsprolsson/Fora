namespace Fora.Server.Services.ThreadService
{
    public interface IThreadService
    {
        Task<ThreadModel> CreateThread(ThreadCreateDto thread);
        Task<List<ThreadModel>> GetThreads(int interestId);
        Task<ThreadModel> GetThread(int threadId);
        Task UpdateThread(ThreadUpdateDto thread);
        Task DeleteThread(int threadId);
    }
}
