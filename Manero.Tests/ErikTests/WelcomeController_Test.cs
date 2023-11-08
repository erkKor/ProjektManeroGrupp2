using Manero.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manero.Tests
{
    public class WelcomeController_Test
    {
        [Fact]
        public void WelcomeController_TestIfUserGetsCookie()
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
