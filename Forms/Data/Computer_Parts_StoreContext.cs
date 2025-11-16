using System.Collections.Generic;
using System.IO;
using Computer_Parts_Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Computer_Parts_Store.Data
{
    public class Computer_Parts_StoreContext : DbContext
    {
        // DbSet для всіх таблиць
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PrebuiltComputer> PrebuiltComputers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public Computer_Parts_StoreContext() { }
        public Computer_Parts_StoreContext(DbContextOptions<Computer_Parts_StoreContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                // Зміна з SQL Server на SQLite
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Налаштування зв'язку багато-до-багатьох для PrebuiltComputer та Product
            modelBuilder.Entity<PrebuiltComputer>()
                .HasMany(pc => pc.Products)
                .WithMany(p => p.PrebuiltComputers)
                .UsingEntity<Dictionary<string, object>>(
                    "PrebuiltComputerProduct",
                    j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                    j => j.HasOne<PrebuiltComputer>().WithMany().HasForeignKey("PrebuiltComputerId")
                );

            // Унікальні індекси
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Article)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();
        }
    }
}