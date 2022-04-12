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
                Email = "mårten@gmail.com",
                LockoutEnabled = false,
            };
            mårten.PasswordHash = passwordHasher.HashPassword(mårten, "mårten");

            builder.Entity<ApplicationUser>().HasData(admin, jesper, filip, mårten);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895712", Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" },
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895713", Name = "Banned", ConcurrencyStamp = "3", NormalizedName = "BANNED" },
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895714", Name = "Deleted", ConcurrencyStamp = "4", NormalizedName = "DELETED" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895712", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895712", UserId = "b74ddd14-6340-4840-95c2-db12554843e6" },
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895713", UserId = "b74ddd14-6340-4840-95c2-db12554843e7" },
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895714", UserId = "b74ddd14-6340-4840-95c2-db12554843e8" }
                );
        }
    }

}