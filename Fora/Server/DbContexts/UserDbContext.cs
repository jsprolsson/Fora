using Fora.Shared.Entities;
using Microsoft.AspNetCore.Identity;

namespace Fora.Server.DbContexts
{
    public class UserDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            this.SeedRoles(builder);
            this.SeedUserRoles(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            ApplicationUser admin = new()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                ForaUser = 1,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
            };
            admin.PasswordHash = passwordHasher.HashPassword(admin, "admin");

            ApplicationUser jesper = new()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e6",
                ForaUser = 2,
                UserName = "Jesper",
                NormalizedUserName = "JESPER",
                Email = "jesper@gmail.com",
                NormalizedEmail = "JESPER@GMAIL.COM",
                LockoutEnabled = false,
            };
            jesper.PasswordHash = passwordHasher.HashPassword(jesper, "jesper");

            ApplicationUser filip = new()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e7",
                ForaUser = 3,
                Banned = true,
                UserName = "Filip",
                NormalizedUserName = "FILIP",
                Email = "filip@gmail.com",
                NormalizedEmail = "FILIP@GMAIL.COM",
                LockoutEnabled = false,
            };
            filip.PasswordHash = passwordHasher.HashPassword(filip, "filip");

            ApplicationUser mårten = new()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e8",
                ForaUser = 4,
                Deleted = true,
                UserName = "Mårten",
                NormalizedUserName = "MÅRTEN",
                Email = "marten@gmail.com",
                NormalizedEmail = "MARTEN@GMAIL.COM",
                LockoutEnabled = false,
            };
            mårten.PasswordHash = passwordHasher.HashPassword(mårten, "mårten");

            ApplicationUser dragan = new()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e9",
                ForaUser = 5,
                Deleted = false,
                UserName = "Dragan",
                NormalizedUserName = "DRAGAN",
                Email = "dragan@gmail.com",
                NormalizedEmail = "DRAGAN@GMAIL.COM",
                LockoutEnabled = false,
            };
            dragan.PasswordHash = passwordHasher.HashPassword(dragan, "dragan");

            builder.Entity<ApplicationUser>().HasData(admin, jesper, filip, mårten, dragan);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "AdminId", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = "UserId", Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" },
                new IdentityRole() { Id = "BannedId", Name = "Banned", ConcurrencyStamp = "3", NormalizedName = "BANNED" },
                new IdentityRole() { Id = "DeletedId", Name = "Deleted", ConcurrencyStamp = "4", NormalizedName = "DELETED" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "AdminId", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },
                new IdentityUserRole<string>() { RoleId = "UserId", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },
                new IdentityUserRole<string>() { RoleId = "UserId", UserId = "b74ddd14-6340-4840-95c2-db12554843e6" },
                new IdentityUserRole<string>() { RoleId = "BannedId", UserId = "b74ddd14-6340-4840-95c2-db12554843e7" },
                new IdentityUserRole<string>() { RoleId = "DeletedId", UserId = "b74ddd14-6340-4840-95c2-db12554843e8" },
                new IdentityUserRole<string>() { RoleId = "UserId", UserId = "b74ddd14-6340-4840-95c2-db12554843e9" }
                );
        }
    }

}