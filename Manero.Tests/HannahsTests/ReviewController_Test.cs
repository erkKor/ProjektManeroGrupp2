using System.Threading.Tasks;
using Manero.Contexts;
using Manero.Controllers;
using Manero.Helpers.Services;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Manero.Tests.HannahsTests;

public class ReviewControllerTests
{
    [Fact]
    public async Task Should_Create_AReviewAndCorrespondingMiddleTableToProduct()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;

        using (var context = new DataContext(options))
        {
            var reviewServiceMock = new Mock<IReviewService>();
            var productDetailsServiceMock = new Mock<ProductDetailsService>(context); // Provide DataContext mock as a constructor parameter
            var controller = new ReviewController(reviewServiceMock.Object, productDetailsServiceMock.Object);

            var reviewModel = new ReviewViewModel
            {
                Rating = 5,
                Text = "Test Review",
                ProductId = 123,
                CreatedAt = DateTime.Now
            };

            var reviewId = 1;

            reviewServiceMock.Setup(x => x.CreateAsync(It.IsAny<ReviewViewModel>()))
                 .ReturnsAsync(reviewId);

            // Act
            var result = await controller.Index(reviewModel) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);

            // Verify that CreateAsync was called with the correct model
            reviewServiceMock.Verify(x => x.CreateAsync(It.IsAny<ReviewViewModel>()), Times.Once);

            // Verify that AddProductReviewAsync was called with the correct parameters
            reviewServiceMock.Verify(x => x.AddProductReviewAsync(reviewModel.ProductId, reviewId), Times.Once);
        }
    }
}
