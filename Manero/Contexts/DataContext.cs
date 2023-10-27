using Manero.Models.Entities;
using Manero.Models.Identity;
using Microsoft.AspNetCore.Identity;
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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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
        }
    }
}
