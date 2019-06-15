using ChatApp.DataAccess.Configs;
using ChatApp.Domains;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.DataAccess.Data
{
    public class ChatAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ChatAppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
