namespace Fora.Server.Services.ThreadService
{
    public class ThreadService : IThreadService
    {
        private readonly AppDbContext _appDbContext;

        public ThreadService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public async Task<ThreadModel> CreateThread(ThreadCreateDto thread)
        {
            var allThreads = await GetThreads(thread.InterestId);

            var findDuplicate = allThreads.Any(i => i.Name.ToLower() == thread.Name.ToLower());
            if (!findDuplicate)
            {
                var threadToCreate = new ThreadModel()
                {
                    Name = thread.Name,
                    UserId = thread.UserId,
                    InterestId = thread.InterestId
                };

                await _appDbContext.AddAsync(threadToCreate);
                var created = await _appDbContext.SaveChangesAsync();
                if (created < 1) return new ThreadModel();
                else return threadToCreate;
            }
            return null;
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

            return await _appDbContext.Threads
                .Include(t => t.Messages)
                .Include(t => t.User)
                .Where(t => t.InterestId == interestId)
                .OrderBy(t => t.Name).ToListAsync();
        }

        public async Task<List<ThreadModel>> GetUserCreatedThreads(int userId)
        {
            return await _appDbContext.Threads.Where(t => t.UserId == userId).Include(t => t.Messages).ToListAsync();
        }

        public async Task UpdateThread(ThreadUpdateDto threadToUpdate)
        {
            //Hämtar threadEntity som berättar vilken thread som ska få dem nya värdena thread som passeras in.
            var threadEntity = await _appDbContext.Threads.FirstOrDefaultAsync(i => i.Id == threadToUpdate.Id);

            ThreadModel thread = new()
            {
                Id = threadToUpdate.Id,
                Name = threadToUpdate.Name,
                DateTimeCreated = threadEntity.DateTimeCreated,
                DateTimeModified = DateTime.Now,
                InterestId = threadToUpdate.InterestId,
                UserId = threadToUpdate.UserId,
            };

            if (threadEntity is not null)
            {
                //Overridear värdena som finns i threadEntity med dem nya.
                _appDbContext.Entry(threadEntity).CurrentValues.SetValues(thread);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
