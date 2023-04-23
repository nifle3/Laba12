using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace App
{
    internal class Context : DbContext
    {
        private const string ConnectionString = "Data\r\nSource=(localdb)\\\\mssqllocaldb;Initial Catalog=LibraryDb;Integrated\r\nSecurity=True;";

        public DbSet<Client> Clients { get; set; }
        public DbSet<Selling> sellings { get; set; }

        public Context()=>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=>
            optionsBuilder.UseSqlServer(ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(u => u.Sellings)
                .WithOne(b => b.Client)
                .HasForeignKey(b => b.ClientId);
        }
    }
}
