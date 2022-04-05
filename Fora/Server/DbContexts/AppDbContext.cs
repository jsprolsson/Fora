using Microsoft.EntityFrameworkCore;

namespace Fora.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<InterestModel> Interests { get; set; }
        public DbSet<ThreadModel> Threads { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many to many (users can have many interests that in turns have many users)
            modelBuilder.Entity<UserInterestModel>()
                .HasKey(ui => new { ui.UserId, ui.InterestId });
            modelBuilder.Entity<UserInterestModel>()
                .HasOne(ui => ui.User)
                .WithMany(u => u.UserInterests)
                .HasForeignKey(ui => ui.UserId);
            modelBuilder.Entity<UserInterestModel>()
                .HasOne(ui => ui.Interest)
                .WithMany(i => i.UserInterests)
                .HasForeignKey(ui => ui.InterestId);

            // Restrict deletion of interest on user delete (set user to null instead)
            modelBuilder.Entity<InterestModel>()
                .HasOne(i => i.User)
                .WithMany(u => u.Interests)
                .HasForeignKey(i => i.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // Restrict deletion of thread on user delete (set user to null instead)
            modelBuilder.Entity<ThreadModel>()
                .HasOne(i => i.User)
                .WithMany(u => u.Threads)
                .HasForeignKey(i => i.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // Restrict deletion of thread on message delete (set user to null instead)
            modelBuilder.Entity<MessageModel>()
                .HasOne(i => i.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(i => i.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<UserModel>()
                .HasData(new UserModel { Id = 1, Username = "Jesper", Banned = false, Deleted = false });

            modelBuilder.Entity<UserModel>()
                .HasData(new UserModel { Id = 2, Username = "Filip", Banned = false, Deleted = false });

            modelBuilder.Entity<InterestModel>()
                .HasData(new InterestModel { Id = 1, Name = "Games", UserId = 1 });

            modelBuilder.Entity<InterestModel>()
                .HasData(new InterestModel { Id = 2, Name = "Books", UserId = 2 });

            modelBuilder.Entity<UserInterestModel>()
                .HasData(new UserInterestModel { UserId = 1, InterestId = 1 });

            modelBuilder.Entity<UserInterestModel>()
                .HasData(new UserInterestModel { UserId = 2, InterestId = 2 });

            modelBuilder.Entity<ThreadModel>()
                .HasData(new ThreadModel { Id = 1, Name = "Elden Ring", UserId = 1, InterestId = 1 });

            modelBuilder.Entity<ThreadModel>()
                .HasData(new ThreadModel { Id = 2, Name = "Blazors guide to the universe", UserId = 2, InterestId = 2 });

            modelBuilder.Entity<MessageModel>()
                .HasData(new MessageModel { Id = 1, ThreadId = 1, UserId = 1, Message = "I love the new elden ring game"});

        }
    }
}
