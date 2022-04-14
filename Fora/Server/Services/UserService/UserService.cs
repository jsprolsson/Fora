
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
                await ChangeAllUserRoles(userToBan, "Banned");

                var foraUserToBan = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userToBan.ForaUser);
                foraUserToBan.Banned = true;
                await _appDbContext.SaveChangesAsync();
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

        public async Task DeactivateUser(string username)
        {
            var userToDelete = await _signInManager.UserManager.FindByNameAsync(username);
            var foraUserToDelete = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userToDelete.ForaUser);

            userToDelete.Deleted = true;
            await ChangeAllUserRoles(userToDelete, "Deleted");

            foraUserToDelete.Deleted = true;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(string username)
        {
            var userToDelete = await _signInManager.UserManager.FindByNameAsync(username);
            var foraUserToDelete = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userToDelete.ForaUser);
            if (userToDelete != null)
            {
                if (userToDelete.Deleted) // Remove user from database
                {
                    await _signInManager.UserManager.DeleteAsync(userToDelete);
                    // Remove user from appDb
                    //_appDbContext.Remove(foraUserToDelete);
                    //await _appDbContext.SaveChangesAsync();
                }
                //else // Mark user as Deleted
                //{
                //    userToDelete.Deleted = true;
                //    await ChangeAllUserRoles(userToDelete, "Deleted");

                //    foraUserToDelete.Deleted = true;
                //    await _appDbContext.SaveChangesAsync();
                //}
            }
        }

        public async Task<List<UserRoleDto>> GetAllUsers()
        {
            //var allApplicationUsers = await _signInManager.UserManager.Users.ToListAsync();
            //List<UserRoleDto> allUsers = new List<UserRoleDto>();
            //foreach (var user in allApplicationUsers)
            //{
            //    allUsers.Add(new UserRoleDto
            //    {
            //        Username = user.UserName,
            //        Role = user.
            //    }
            //}
            return null;
        }

        public async Task RemoveBan(string username)
        {
            var userToRemoveBan = await _signInManager.UserManager.FindByNameAsync(username);
            if (userToRemoveBan != null)
            {
                userToRemoveBan.Banned = false;
                await ChangeAllUserRoles(userToRemoveBan, "User");

                var foraUserToRemoveBan = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userToRemoveBan.ForaUser);
                foraUserToRemoveBan.Banned = false;
                await _appDbContext.SaveChangesAsync();
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
        private async Task<bool> ChangeAllUserRoles(ApplicationUser user, string newRole)
        {
            var allRoles = await _signInManager.UserManager.GetRolesAsync(user);
            await _signInManager.UserManager.RemoveFromRolesAsync(user, allRoles);
            await _signInManager.UserManager.AddToRoleAsync(user, newRole);
            var result = await _userDbContext.SaveChangesAsync();
            if (result > 0) return true;
            return false;
        }
        private async Task<IList<string>> GetUserRole(ApplicationUser user)
        {
            var roles = await _signInManager.UserManager.GetRolesAsync(user);
            return roles;
        }
    }
}
