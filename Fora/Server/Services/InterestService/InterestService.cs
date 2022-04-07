using Microsoft.EntityFrameworkCore;

namespace Fora.Server.Services.InterestService
{
    public class InterestService : IInterestService
    {
        private readonly AppDbContext _appDbContext;

        public InterestService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public async Task<InterestModel> CreateInterest(InterestCreateDto interest)
        {
            var interestModel = new InterestModel()
            {
                Name = interest.Name,
                UserId = interest.UserId,
            };

            _appDbContext.Add(interestModel);
            var created = await _appDbContext.SaveChangesAsync();
            if (created < 1) return new InterestModel();
            else return null;
        }

        public async Task DeleteInterest(int interestId)
        {
            InterestModel interestToDelete = new();
            interestToDelete.Id = interestId;
            _appDbContext.Remove(interestToDelete);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<InterestModel?> GetInterest(int interestId)
        {
            return await _appDbContext.Interests.Where(i => i.Id == interestId).FirstOrDefaultAsync();
        }

        public async Task<List<InterestModel>> GetInterests()
        {
            return await _appDbContext.Interests.OrderBy(i => i.Name).ToListAsync();
        }

        public async Task UpdateInterest(InterestModel interest)
        {
            var interestEntity = await _appDbContext.Interests.FirstOrDefaultAsync(i => i.Id == interest.Id);
            if (interestEntity is not null)
            {
                _appDbContext.Entry(interestEntity).CurrentValues.SetValues(interest);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
