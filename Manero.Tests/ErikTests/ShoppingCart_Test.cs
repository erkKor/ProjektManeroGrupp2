using Manero.Contexts;
using Manero.Helpers.Repositories;
using Manero.Helpers.Services;
using Manero.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manero.Tests.ErikTests
{
    public class ShoppingCart_Test : IDisposable
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly ShoppingCartService _shoppingCartService;

        public ShoppingCart_Test()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            _context = new DataContext(_options);

            SeedData(_context);

            var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            var mockCartItemRepository = new CartItemRepository(_context);
            _shoppingCartService = new ShoppingCartService(mockHttpContextAccessor.Object, new ShoppingCartRepository(_context), mockCartItemRepository);
        }

        private void SeedData(DataContext context)
        {
            context.CartItems.Add(new CartItemEntity {CartItemId = 1, ShoppingCartId = 1, ProductId= 1, Name = "Test Product 1", Price = 10, Quantity = 1 });
            context.CartItems.Add(new CartItemEntity {CartItemId = 2, ShoppingCartId = 2, ProductId= 2, Name = "Test Product 2", Price = 20, Quantity = 1 });
            context.SaveChanges();
        }

        [Fact]
        public async Task Get_ShoppingCartListAsync_ByShoppingCartID()
        {
            // Arrange
            int shoppingCartId = 1;

            // Act
            var cartItems = await _shoppingCartService.GetCartItemsFromDBAsync(shoppingCartId);

            // Assert
            Assert.NotEmpty(cartItems);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
