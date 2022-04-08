
using Fora.Server.DbContexts;
using Fora.Server.Services.AuthService;

namespace Fora.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserDbContext _userDbContext;
        private readonly IAuthService _authService;

        public UserService(AppDbContext appDbContext,
            SignInManager<ApplicationUser> signInManager,
            UserDbContext userDbContext,
            IAuthService AuthService)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userDbContext = userDbContext ?? throw new ArgumentNullException(nameof(userDbContext));
            _authService = AuthService ?? throw new ArgumentNullException(nameof(AuthService));
        }
        public async Task AddUserInterest(int foraUserId, int interestId)
        {
            UserInterestModel newUserInterest = new UserInterestModel
            {
                UserId = foraUserId,
                InterestId = interestId,
            };
            _appDbContext.Add(newUserInterest);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task BanUser(string userId)
        {
            var userToChange = await _signInManager.UserManager.FindByIdAsync(userId);
            if (userToChange != null)
            {
                userToChange.Banned = true;
                await _userDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(string userId)
        {
            var userToChange = await _signInManager.UserManager.FindByIdAsync(userId);
            if (userToChange != null)
            {
                userToChange.Deleted = true;
                await _userDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<InterestModel>> GetUserInterests()
        {
            var foraUserId = _authService.GetForaUserId();
            return await _appDbContext.Interests
                            .Include(ui => ui.UserInterests)
                            .Where(u => u.UserId == foraUserId).ToListAsync();
        }

        public Task<List<string>> GetUserRoles(string userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUserInterest(int interestId)
        {
            throw new NotImplementedException();
        }

        public async Task UnBanUser(string userId)
        {
            var userToChange = await _signInManager.UserManager.FindByIdAsync(userId);
            if (userToChange != null)
            {
                userToChange.Banned = false;
                await _userDbContext.SaveChangesAsync();
            }
        }
        public async Task UnDeleteUser(string userId)
        {
            var userToChange = await _signInManager.UserManager.FindByIdAsync(userId);
            if (userToChange != null)
            {
                userToChange.Deleted = false;
                await _userDbContext.SaveChangesAsync();
            }
        }
    }
}
