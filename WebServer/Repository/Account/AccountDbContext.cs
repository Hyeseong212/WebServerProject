﻿using Microsoft.EntityFrameworkCore;
using WebServer.Model.DbEntity;

namespace WebServer.Repository
{
    public class AccountDbContext : DbContext
    {
        public DbSet<AccountEntity> Account { get; set; }
        public DbSet<AccountCharacterEntity> AccountCharacter { get; set; }
        public DbSet<AccountCurrencyEntity> AccountCurrency { get; set; }
        public DbSet<AccountNickNameEntity> AccountNickName { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = "server=127.0.0.1; port=3306; database=WebServerDB; user=root; password=1234";
            string connectionString = "server=192.168.123.1; port=3306; database=WebServerDB; user=root; password=1234";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountEntity>().HasKey(x => x.AccountId);
            modelBuilder.Entity<AccountCharacterEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<AccountCurrencyEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<AccountNickNameEntity>().HasKey(x => x.Id);
        }
    }
}
