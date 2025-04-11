using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistence
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> option) : base(option) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                 .HasMany(x => x.Addresses)
                 .WithOne(u => u.User)
                 .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<Category>()
             .HasMany(x => x.Products)
             .WithOne(u => u.Category)
             .HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<Product>()
               .HasOne(x => x.Inventory)
               .WithOne(u => u.Product)
               .HasForeignKey<Inventory>(a => a.ProductId);
        }

    }
}
