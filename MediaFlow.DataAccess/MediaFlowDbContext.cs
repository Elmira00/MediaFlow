using MediaFlow.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaFlow.DataAccess
{
    public class MediaFlowDbContext : DbContext
    {
        public MediaFlowDbContext(DbContextOptions<MediaFlowDbContext> options)
       : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<SocialMediaPlatform> SocialMediaPlatforms { get; set; }
        public DbSet<UserSocialMediaAccount> UserSocialMediaAccounts { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<ContentPost> ContentPosts { get; set; }
        public DbSet<ScheduledPost> ScheduledPosts { get; set; }
        public DbSet<PostHistory> PostHistories { get; set; }
        public DbSet<Analytics> Analytics { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MediaFlowDb;Integrated Security=True;"); // Your connection string here
            }
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(
        //            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MediaFlowDb;Integrated Security=True;",
        //            sqlOptions => sqlOptions.MigrationsAssembly("MediaFlow.WebServerSide"));
        //    }
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Add additional configurations here if needed
        //}
    }

}
