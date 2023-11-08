using Manero.Controllers;
using Manero.Helpers.Services;
using Manero.Models.Identity;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manero.Tests
{
    public class LoginTest
    {
        private readonly SignUpService _signUpService;
        private readonly Mock<UserManager<AppUser>> _userManagerMock;

        public LoginTest()
        {
            _userManagerMock = new Mock<UserManager<AppUser>>(
                new Mock<IUserStore<AppUser>>().Object,
                null!, null!, null!, null!, null!, null!, null!, null!);

            _signUpService = new SignUpService(_userManagerMock.Object);
        }


        [Fact]
        public async Task SignUpAsync_CheckIf_User_gets_Created()
        {
            // Arrange
            var signUpViewModel = new SignUpViewModel
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "test@domain.com",
                Password = "Bytmig123!",
                ConfirmPassword = "Bytmig123!"
            };

            // Act
            var result = await _signUpService.SignUpAsync(signUpViewModel);

            // Assert
            Assert.True(result);
            Assert.IsType<SignUpViewModel>(signUpViewModel);
        }
    }
}
