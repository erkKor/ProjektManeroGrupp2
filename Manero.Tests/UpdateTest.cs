using Manero.Controllers;
using Manero.Models.Identity;
using Manero.Models.ViewModels;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Manero.Tests
{
    public class EditProfileControllerTests
    {
        [Fact]
        public async void UpdateUser_ValidModel_ReturnsRedirectToActionResult()
        {
            // Arrange
            var userManagerMock = new Mock<UserManager<AppUser>>();
            var signInManagerMock = new Mock<SignInManager<AppUser>>();

            var controller = new EditProfileController(userManagerMock.Object, signInManagerMock.Object);
            // Fyll i testdata i modellen här
            var model = new EditProfileVM
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "123-456-7890",
                // Fyll i övrig testdata här
            };


            // Act
            var result = await controller.UpdateUser(model);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var redirectToAction = (RedirectToActionResult)result;
            Assert.Equal("Index", redirectToAction.ActionName);
            Assert.Equal("Home", redirectToAction.ControllerName);
        }
    }
}