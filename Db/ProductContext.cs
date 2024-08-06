using APITest.Models;
using Microsoft.EntityFrameworkCore;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Category1" },
            new Category { Id = 2, Name = "Category2" },
            new Category { Id = 3, Name = "Category3" },
            new Category { Id = 4, Name = "Category4" },
            new Category { Id = 5, Name = "Category5" },
            new Category { Id = 6, Name = "Category6" },
            new Category { Id = 7, Name = "Category7" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Product1", Description = "Description1", Price = 10.0, CategoryId = 6 },
            new Product { Id = 2, Name = "Product2", Description = "Description2", Price = 20.0, CategoryId = 2 },
            new Product { Id = 3, Name = "Product3", Description = "Description3", Price = 30.0, CategoryId = 1 },
            new Product { Id = 4, Name = "Product4", Description = "Description4", Price = 40.0, CategoryId = 5 },
            new Product { Id = 5, Name = "Product5", Description = "Description5", Price = 50.0, CategoryId = 5 },
            new Product { Id = 6, Name = "Product6", Description = "Description6", Price = 60.0, CategoryId = 6 },
            new Product { Id = 7, Name = "Product7", Description = "Description7", Price = 70.0, CategoryId = 5 },
            new Product { Id = 8, Name = "Product8", Description = "Description8", Price = 80.0, CategoryId = 1 },
            new Product { Id = 9, Name = "Product9", Description = "Description9", Price = 90.0, CategoryId = 2 },
            new Product { Id = 10, Name = "Product10", Description = "Description10", Price = 100.0, CategoryId = 1 }
        );

        base.OnModelCreating(modelBuilder);
    }
}