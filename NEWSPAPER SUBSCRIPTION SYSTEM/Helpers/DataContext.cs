using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Entities;

namespace NEWSPAPER_SUBSCRIPTION_SYSTEM.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Configuration.GetConnectionString("NplDatabase"));
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<NewsPaper> NewsPapers { get; set; }
    }
}