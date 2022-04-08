
using Fora.Server.DbContexts;

namespace Fora.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserDbContext _userDbContext;

        public UserService(AppDbContext appDbContext, SignInManager<ApplicationUser> signInManager, UserDbContext userDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userDbContext = userDbContext ?? throw new ArgumentNullException(nameof(userDbContext));
        }
        public async Task AddUserInterest(int interestId)
        {

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
