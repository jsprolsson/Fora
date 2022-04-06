namespace Fora.Server.Services.ThreadService
{
    public class ThreadService : IThreadService
    {
        private readonly AppDbContext _appDbContext;

        public ThreadService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public async Task<ThreadModel> CreateThread(ThreadDto thread)
        {
            var threadToCreate = new ThreadModel()
            {
                Id = thread.Id,
                Name = thread.Name,
                UserId = thread.UserId,
                InterestId = thread.InterestId
            };

            await _appDbContext.AddAsync(threadToCreate);
            var created = await _appDbContext.SaveChangesAsync();
            if (created < 1) return new ThreadModel();
            else return threadToCreate;
        }

        public async Task DeleteThread(int threadId)
        {
            ThreadModel threadToDelete = new();
            threadToDelete.Id = threadId;
            _appDbContext.Remove(threadToDelete);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<ThreadModel> GetThread(int threadId)
        {
            return await _appDbContext.Threads.Where(i => i.Id == threadId).FirstOrDefaultAsync();
        }

        public async Task<List<ThreadModel>> GetThreads(int interestId)
        {
            //Ska inte kunna hämta alla trådar sammanlagt. Bara alla trådar för ett intresse.

            //Plocka in intresse-id:t, jämför och hitta alla trådar som har detta intresse:idt

            return await _appDbContext.Threads.Where(t => t.InterestId == interestId).OrderBy(t => t.Name).ToListAsync();
        }

        public async Task UpdateThread(ThreadDto thread)
        {
            var threadEntity = await _appDbContext.Threads.FirstOrDefaultAsync(i => i.Id == thread.Id);
            if (threadEntity is not null)
            {
                _appDbContext.Entry(threadEntity).CurrentValues.SetValues(thread);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
