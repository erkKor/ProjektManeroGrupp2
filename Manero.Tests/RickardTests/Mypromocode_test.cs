using Manero.Controllers;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Tests.RickardTests
{
    public class Mypromocode_test
    {

        public class GenerateRandomCompanyName_test
        {
            [Fact]
            public void GenerateRandomCompanyName_Should_Set_a_Random_CompanyName()
            {
                // Arrange
                var model = new MyPromoViewModel();

                // Act
                model.GenerateRandomCompanyName();

                // Assert
                Assert.NotNull(model.CompanyName_1);
                Assert.NotNull(model.CompanyName_2);
                Assert.NotNull(model.CompanyName_3);
            }

        }

        public class MyPromocodesControllerTests
        {
            [Fact]
            public void Index_Should_Return_View_With_Model()
            {
                // Arrange
                var controller = new MyPromocodesController();
                var model = new MyPromoViewModel();

                // Act
                var result = controller.Index(model) as ViewResult;

                // Assert
                Assert.NotNull(result);
                Assert.True(result.ViewName == null || result.ViewName == "index");
                Assert.Same(model, result.Model);
            }
        }

        public class MyPromocodesAddControllerTests
        {
            [Fact]
            public void Index_Post_Should_Redirect_To_Mypromocodes_Index_With_Model()
            {
                // Arrange
                var controller = new MyPromocodesAddController();
                var model = new MyPromoViewModel();

                // Act
                var result = controller.Index(model) as RedirectToActionResult;

                // Assert
                Assert.NotNull(result);
                Assert.Equal("index", result.ActionName, ignoreCase: true);
                Assert.Equal("Mypromocodes", result.ControllerName);
            }
        }

    }
}
