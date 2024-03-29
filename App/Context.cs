﻿using Microsoft.EntityFrameworkCore;
using System;

namespace App
{
    public class Context : DbContext
    {
        private const string connectionString = 
            @"Server=(localdb)\mssqllocaldb;Database=Laba12Dbv3;Trusted_Connection=True;";

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Selling> Sellings => Set<Selling>();

        public Context()=>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=>
            optionsBuilder.UseSqlServer(connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(u => u.Sellings)
                .WithOne(b => b.Client)
                .HasForeignKey(b => b.ClientId);
        }
    }
}
