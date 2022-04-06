namespace Fora.Server.Services.ThreadService
{
    public interface IThreadService
    {
        Task<ThreadModel> CreateThread(ThreadModel thread);
        Task<List<ThreadModel>> GetThreads(int interestId);
        Task<ThreadModel> GetThread(int threadId);
        Task UpdateThread(ThreadDto thread);
        Task DeleteThread(int threadId);
    }
}
