
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

        public async Task AddRole(UserRoleDto userRole)
        {
            var user = await _signInManager.UserManager.FindByNameAsync(userRole.Username);
            var result = await _signInManager.UserManager.AddToRoleAsync(user, userRole.Role);
        }

        public async Task BanUser(string username)
        {
            var userToBan = await _signInManager.UserManager.FindByNameAsync(username);
            if (userToBan != null)
            {
                userToBan.Banned = true;
                await _userDbContext.SaveChangesAsync();
            }
        }

        public async Task ChangePassword(UserChangePasswordDto userChangePassword)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(userChangePassword.Username, userChangePassword.CurrentPassword, false, false);
            if (signInResult.Succeeded)
            {
                var user = await _signInManager.UserManager.FindByNameAsync(userChangePassword.Username);
                var result = await _signInManager.UserManager.ChangePasswordAsync(user, userChangePassword.CurrentPassword, userChangePassword.NewPassword);
            }
        }

        public async Task DeleteUser(string username)
        {
            var userToDelete = await _signInManager.UserManager.FindByNameAsync(username);
            if (userToDelete != null)
            {
                await _signInManager.UserManager.DeleteAsync(userToDelete);
                //await _userDbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveBan(string username)
        {
            var userToRemoveBan = await _signInManager.UserManager.FindByNameAsync(username);
            if (userToRemoveBan != null)
            {
                userToRemoveBan.Banned = false;
                await _userDbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveRole(UserRoleDto userRole)
        {
            var user = await _signInManager.UserManager.FindByNameAsync(userRole.Username);
            var result = await _signInManager.UserManager.RemoveFromRoleAsync(user, userRole.Role);
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
