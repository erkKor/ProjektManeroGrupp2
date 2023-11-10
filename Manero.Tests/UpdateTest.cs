using System.Security.Claims;
using System.Threading.Tasks;
using Manero.Controllers;
using Manero.Models.Identity;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Manero.Tests
{

    public class EditProfileControllerTests
    {
        [Fact]
        public async Task UpdateUser_InvalidModel_ReturnsViewWithErrors()
        {
            // Arrange
            var controller = new EditProfileController(null, null); // Använd null för UserManager och SignInManager eftersom vi inte kommer använda dem i detta test.

            // Lägg till modellfel manuellt
            controller.ModelState.AddModelError("FirstName", "FirstName is required"); 

            // Act
            var result = await controller.UpdateUser(new EditProfileVM());

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            // Kontrollera att felmeddelanden finns i modellen
            Assert.False(controller.ModelState.IsValid);
            Assert.True(controller.ModelState.ContainsKey("FirstName"));
            var error = controller.ModelState["FirstName"].Errors[0];
            Assert.Equal("FirstName is required", error.ErrorMessage);
        }


        [Fact]
        public void EditProfileVM_PropertiesShouldWorkAsExpected()
        {
            // Arrange
            var model = new EditProfileVM();

            // Act
            model.FirstName = "John";
            model.LastName = "Doe";
            model.Email = "johndoe@example.com";
            model.PhoneNumber = "123-456-7890";

            // Assert
            Assert.Equal("John", model.FirstName);
            Assert.Equal("Doe", model.LastName);
            Assert.Equal("johndoe@example.com", model.Email);
            Assert.Equal("123-456-7890", model.PhoneNumber);
        }
    }


}