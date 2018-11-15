using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Products> ProductsList { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasKey(p => p.Id);

            modelBuilder.Entity<Products>().Property(p => p.Id)
                .IsRequired();

            modelBuilder.Entity<Products>().Property(p => p.Price)
                .HasDefaultValue(0)
                .IsRequired();

            modelBuilder.Entity<Products>().Property(p => p.Pieces)
                .HasDefaultValue(0)
                .IsRequired();

            modelBuilder.Entity<ShoppingCart>().HasKey(p => p.Id);
            modelBuilder.Entity<ShoppingCart>().Property(p => p.Id)
                .IsRequired();
        }
    }
}
