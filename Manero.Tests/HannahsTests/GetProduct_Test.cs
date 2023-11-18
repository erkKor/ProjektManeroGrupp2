
using System.Linq.Expressions;
using Manero.Contexts;
using Manero.Controllers;
using Manero.Helpers.Services;
using Manero.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Manero.Tests.HannahsTests
{
    public class GetProduct_Test
    {
        [Fact]
        public async Task Should_Return_AProductUsingProductId()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            using (var context = new DataContext(options))
            {
                context.ProductDetails.Add(new ProductDetailsEntity { ProductId = 1, Name = "Shirt", Description = "blabla", Price = 5 });

                var expectedProduct = new ProductDetailsEntity
                {
                    ProductId = 1,
                    Name = "Product",
                    Description = "bla",
                    Price = 5
                };


                var productServiceMock = new Mock<IProductDetailsService>();
                productServiceMock.Setup(x => x.GetAsync(It.IsAny<Expression<Func<ProductDetailsEntity, bool>>>()))
                                  .ReturnsAsync(expectedProduct);

                var controller = new ProductDetailsController(productServiceMock.Object, context);

                var expectedProductId = 1;

                // Act
                var result = await controller.Product(expectedProductId) as ViewResult;

                // Assert
                Assert.NotNull(result);
                var model = Assert.IsType<ProductDetailsEntity>(result.Model);
                Assert.Equal(expectedProduct.ProductId, model.ProductId);
            }
        }
    }
}