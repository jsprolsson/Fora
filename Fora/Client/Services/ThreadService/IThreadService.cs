namespace Fora.Client.Services.ThreadService
{
    public interface IThreadService
    {
        Task<ThreadModel> GetThread(ThreadDto thread);
        Task<List<ThreadModel>> GetThreads(int interestId);
        Task<List<ThreadModel>> GetUserCreatedThreads(int userId, int interestId);
        Task CreateThread(ThreadCreateDto threadToCreate);
        Task UpdateThread(ThreadUpdateDto threadToUpdate);

        Task DeleteThread(ThreadDeleteDto threadToDelete);
    }
}
