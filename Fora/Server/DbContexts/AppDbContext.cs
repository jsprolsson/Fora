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

            // Seed data

            modelBuilder.Entity<UserModel>()
                .HasData(
                new UserModel { Id = 1, Username = "Admin", Banned = false, Deleted = false },
                new UserModel { Id = 2, Username = "Jesper", Banned = false, Deleted = false },
                new UserModel { Id = 3, Username = "Filip", Banned = false, Deleted = false },
                new UserModel { Id = 4, Username = "Mårten", Banned = true, Deleted = false },
                new UserModel { Id = 5, Username = "Dragan", Banned = false, Deleted = false }
                );

            modelBuilder.Entity<InterestModel>()
                .HasData(
                new InterestModel { Id = 1, Name = "Games", UserId = 1 },
                new InterestModel { Id = 2, Name = "Books", UserId = 2 },
                new InterestModel { Id = 3, Name = "Music", UserId = 2 },
                new InterestModel { Id = 4, Name = "Hiking", UserId = 1 }
                );

            modelBuilder.Entity<UserInterestModel>()
                .HasData(
                new UserInterestModel { UserId = 1, InterestId = 1 },
                new UserInterestModel { UserId = 2, InterestId = 2 },
                new UserInterestModel { UserId = 2, InterestId = 3 },
                new UserInterestModel { UserId = 1, InterestId = 2 },
                new UserInterestModel { UserId = 3, InterestId = 4 },
                new UserInterestModel { UserId = 4, InterestId = 2 },
                new UserInterestModel { UserId = 4, InterestId = 1 }
                );

            modelBuilder.Entity<ThreadModel>()
                .HasData(
                new ThreadModel { Id = 2, Name = "Blazors guide to the universe", UserId = 2, InterestId = 2 },
                new ThreadModel { Id = 1, Name = "Elden Ring", UserId = 1, InterestId = 1 },
                new ThreadModel { Id = 3, Name = "Hiking in dr martens??", UserId = 3, InterestId = 4 },
                new ThreadModel { Id = 4, Name = "About twilight...", UserId = 4, InterestId = 2 }
                );

            modelBuilder.Entity<MessageModel>()
                .HasData(
                new MessageModel { Id = 1, ThreadId = 1, UserId = 1, Message = "I love the new elden ring game" },
                new MessageModel { Id = 2, ThreadId = 1, UserId = 4, Message = "I think it's the worst in the series" },
                new MessageModel { Id = 3, ThreadId = 1, UserId = 1, Message = "It's not a part of any series" },
                new MessageModel { Id = 4, ThreadId = 1, UserId = 4, Message = "Yes it is" },
                new MessageModel { Id = 5, ThreadId = 4, UserId = 4, Message = "I've heard they are releasing another book in the twilight franschise" },
                new MessageModel { Id = 6, ThreadId = 4, UserId = 1, Message = "NOBODY CARES" },
                new MessageModel { Id = 7, ThreadId = 4, UserId = 4, Message = "I care" },
                new MessageModel { Id = 8, ThreadId = 4, UserId = 2, Message = "Keep a civil tone in here please and only post regarding the topic." },
                new MessageModel { Id = 9, ThreadId = 4, UserId = 1, Message = "I'm sorry. I'm actually prtty excited 4 the new release" },
                new MessageModel { Id = 10, ThreadId = 3, UserId = 3, Message = "Has anybody tried hiking in dr martens?? And if so, do you have any recommendations for me? I'm going up to Sälen next week and would like a pair of martens, but I've heard they're not that good for hiking in.." }
                );

        }
    }
}
