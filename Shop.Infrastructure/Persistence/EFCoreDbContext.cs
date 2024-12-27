using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistence
{
    public class EFCoreDbContext:DbContext
    {
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> option) : base(option){ }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
             .HasDiscriminator<string>("ProductType")
             .HasValue<RegularProduct>("Regular")
             .HasValue<FragileProduct>("Fragile");

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
