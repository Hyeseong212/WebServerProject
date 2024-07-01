using Microsoft.EntityFrameworkCore;
using WebServer.Model.DbEntity;

namespace WebServer.Repository.Shop
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<InventoryEntity> InventoryEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = "server=127.0.0.1; port=3306; database=WebServerDB; user=root; password=1234";
            string connectionString = "server=192.168.123.1; port=3306; database=WebServerDB; user=root; password=1234";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 코드를 이용해서 테이블을 만들 때, 어떤 형식으로 만들껀지 알려주기 위해 사용
            modelBuilder.Entity<InventoryEntity>().HasKey(x => x.Id);
        }
    }
}