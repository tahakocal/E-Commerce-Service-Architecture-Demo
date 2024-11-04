using ECommerceMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMicroservice.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //add seed data
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Category 1" },
            new Category { Id = 2, Name = "Category 2" }
        );
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Sample Product 1", Price = 11.99m, Stock = 10, CategoryId = 1 },
            new Product { Id = 2, Name = "Sample Product 2", Price = 22.99m, Stock = 120, CategoryId = 1 },
            new Product { Id = 3, Name = "Sample Product 3", Price = 333.99m, Stock = 53, CategoryId = 2 },
            new Product { Id = 4, Name = "Sample Product 4", Price = 444.99m, Stock = 55, CategoryId = 2 }
        );
    }
}