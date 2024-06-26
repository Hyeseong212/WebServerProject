using Microsoft.EntityFrameworkCore;
using WebServer.Model.DbEntity;

namespace WebServer.Repository.Shop
{
    public class ShopDbContext : DbContext
    {
        public DbSet<AccountCurrencyEntity> AccountCurrency { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=127.0.0.1; port=3306; database=WebServerDB; user=root; password=1234";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
