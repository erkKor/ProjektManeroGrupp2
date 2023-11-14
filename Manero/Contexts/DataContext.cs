using Manero.Models.Entities;
using Manero.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Manero.Contexts
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<AdressEntity> Adresses { get; set; }
        public DbSet<UserAdressEntity> UserAdresses { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public DbSet<CartItemEntity> CartItems { get; set; }
        public DbSet<ShoppingCartEntity> ShoppingCarts { get; set; }

        public DbSet<ProductDetailsEntity> ProductDetails { get; set; }

        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<ProductReviewEntity> ProductReviews { get; set; }

        public DbSet<ColorEntity> Colors { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductReviewEntity>()
            .HasKey(pr => new { pr.ProductId, pr.ReviewId });

            builder.Entity<ProductReviewEntity>()
                .HasOne(pr => pr.ProductDetails)
                .WithMany(p => p.ProductReviews)
                .HasForeignKey(pr => pr.ProductId);

            builder.Entity<ProductReviewEntity>()
                .HasOne(pr => pr.Review)
                .WithMany(r => r.ProductReviews)
                .HasForeignKey(pr => pr.ReviewId);

            builder.Entity<ProductColor>()
            .HasKey(pc => new { pc.ProductId, pc.ColorId });

            builder.Entity<ProductColor>()
                .HasOne(pc => pc.ProductDetails)
                .WithMany(p => p.ProductColors)
                .HasForeignKey(pc => pc.ProductId);

            builder.Entity<ProductColor>()
                .HasOne(pc => pc.Color)
                .WithMany(c => c.ProductColors)
                .HasForeignKey(pc => pc.ColorId);

            builder.Entity<CategoryEntity>().HasData
            (
                new CategoryEntity { Id = 1, CategoryName = "New" },
                new CategoryEntity { Id = 2, CategoryName = "Popular" },
                new CategoryEntity { Id = 3, CategoryName = "Featured" },
                new CategoryEntity { Id = 4, CategoryName = "Best Seller" },
                new CategoryEntity { Id = 5, CategoryName = "Pants" },
                new CategoryEntity { Id = 6, CategoryName = "Dresses" },
                new CategoryEntity { Id = 7, CategoryName = "Accessories" },
                new CategoryEntity { Id = 8, CategoryName = "Shoes" },
                new CategoryEntity { Id = 9, CategoryName = "T-shirts" }
            );

            builder.Entity<ProductDetailsEntity>().HasData
              (
                new ProductDetailsEntity { ProductId = 1, Name = "Summer Pants", Description = "White", Price = 31 },
                  new ProductDetailsEntity { ProductId = 2, Name = "t-Shirt", Description = "White", Price = 1000 },
                  new ProductDetailsEntity { ProductId = 3, Name = "Shirt", Description = "Black", Price = 100 }

              );

            builder.Entity<ColorEntity>().HasData
           (
               new ColorEntity { ColorId = 1, Name = "Red" },
               new ColorEntity { ColorId = 2, Name = "Blue" },
               new ColorEntity { ColorId = 3, Name = "Black" },
               new ColorEntity { ColorId = 4, Name = "White" }

           );
        }
    }

    public class MockDataContext : DataContext
    {
        public MockDataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // If you need to pass DbContextOptions, include them here
        }
    }

}
