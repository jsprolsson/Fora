using Fora.Server.Services.AuthService;

namespace Fora.Server.Services.UserInterestService
{
    public class UserInterestService : IUserInterestService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAuthService _authService;

        public UserInterestService(AppDbContext appDbContext,
            IAuthService authService)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }
        public async Task CreateUserInterest(int interestId)
        {
            var foraUserId = _authService.GetForaUserId();
            UserInterestModel newUserInterest = new UserInterestModel
            {
                UserId = foraUserId,
                InterestId = interestId,
            };
            _appDbContext.Add(newUserInterest);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserInterest(int interestId)
        {
            var foraUserId = _authService.GetForaUserId();
            UserInterestModel userInterestToRemove = new UserInterestModel
            {
                UserId = foraUserId,
                InterestId = interestId,
            };
            _appDbContext.Remove(userInterestToRemove);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<InterestModel>> GetUserInterests()
        {
            var foraUserId = _authService.GetForaUserId();
            var userInterests = await _appDbContext.UserInterests
                                .Include(i => i.Interest)
                                .ThenInclude(i => i.Threads)
                                .Where(u => u.UserId == foraUserId)
                                .ToListAsync();
            var interests = userInterests.Select(i => i.Interest).ToList();
            return interests;
        }
    }
}
