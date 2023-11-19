using Manero.Contexts;
using Manero.Helpers.Repositories;
using Manero.Helpers.Services;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manero.Tests.ErikTests
{
    public class ProductService_Test : IDisposable
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly ProductService _productService;

        public ProductService_Test()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            _context = new DataContext(_options);
            SeedData(_context);

            _productService = new ProductService(new ProductRepository(_context));
        }

        private void SeedData(DataContext context)
        {
            context.Products.Add(new ProductEntity { Id = 1, Name = "Test Product 1", Description = " ", Rating = 3 });
            context.Products.Add(new ProductEntity { Id = 2, Name = "Test Product 2", Description = " ", Rating = 3 });
            context.SaveChanges();
        }


        //NEED TO RUN TESTS ONE AT A TIME
        [Fact]
        public async Task GetProductAsync_ByProductId_ReturnsSaidProduct()
        {
            // Arrange
            int productId = 1;

            // Act
            var product = await _productService.GetProductAsync(productId);

            // Assert
            Assert.NotNull(product);
            Assert.Equal(productId, product.Id);
        }

        //NEED TO RUN TESTS ONE AT A TIME
        [Fact]
        public async Task GetAllProductsAsync_ReturnsAllProducts()
        {
            // Act
            var products = await _productService.GetAllProductsAsync();

            // Assert
            Assert.NotEmpty(products);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
