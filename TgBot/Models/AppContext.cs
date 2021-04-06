using Microsoft.EntityFrameworkCore;

namespace TgBot.Models
{
    public class AppContext: DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }

        public AppContext()
        {
            
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string AppConnectionString = Config.ConnectionTobString;

            optionsBuilder.UseNpgsql(AppConnectionString);
        }
    }
}