using Manero.Contexts;
using Manero.Controllers;
using Manero.Helpers.Repositories;
using Manero.Helpers.Services;
using Manero.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;

namespace Manero.Tests
{
    public class ErikTests : IDisposable
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly ProductService _productService;

        public ErikTests()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            _context = new DataContext(_options);

            // Seed the in-memory database with test data
            SeedData(_context);

            _productService = new ProductService(new ProductRepository(_context));
        }

        private void SeedData(DataContext context)
        {
            // Add seed data to the in-memory database for testing purposes
            // For instance:
            context.Products.Add(new ProductEntity { Id = 1, Name = "Test Product 1", Description = " ", Rating = 3 });
            context.Products.Add(new ProductEntity { Id = 2, Name = "Test Product 2", Description = " ", Rating = 3 });

            context.SaveChanges(); 
        }

        [Fact]
        public async Task GetProductAsync_WithValidId_ReturnsProduct()
        {
            // Arrange - No need for mocking, as you're using the in-memory database

            int productId = 1; // Consider this ID might exist in your seeded data

            // Act
            var product = await _productService.GetProductAsync(productId);

            // Assert
            Assert.NotNull(product);
            Assert.Equal(productId, product.Id);
        }

        [Fact]
        public async Task GetAllProductsAsync_ReturnsAllProducts()
        {
            { 
            // Arrange - No need for mocking, as you're using the in-memory database

            // Act
            var products = await _productService.GetAllProductsAsync();

            // Assert
            Assert.NotEmpty(products);
            // Additional assertions based on the seeded data or expectations
        }
        }

        public void Dispose()
        {
            _context.Dispose();
        }


        [Fact]
        public void CookieTest()
        {
            // Arrange
            var controller = new WelcomeController();
            var httpContext = new DefaultHttpContext();
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };
            var expectedCookieName = "hasSeenWelcome";
            var expectedCookieValue = "true"; // Ensure the expected value is a string as cookies store string-based values

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);

            var setCookieHeader = httpContext.Response.Headers["Set-Cookie"];

            // Convert the set-cookie header to a string and check if it contains the expected cookie name and value
            var setCookieString = Assert.Single(setCookieHeader);
            Assert.Contains(expectedCookieName, setCookieString);
            Assert.Contains(expectedCookieValue, setCookieString);
        }
    }
}
