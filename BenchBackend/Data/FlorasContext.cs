using BenchBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchBackend.Data
{
    public class FlorasContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime orderPlaced = new DateTime(2021, 01, 15);
            DateTime orderFulfilled = new DateTime(2021, 01, 18);

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderPlaced = orderPlaced, OrderFulfilled = orderFulfilled }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FlorasDB");
        }
    }
}
