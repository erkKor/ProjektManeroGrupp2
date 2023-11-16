using Manero.Helpers.Services;
using Manero.Models.Identity;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace Manero.Tests;

public class SignInService_Test
{
    private readonly SignInService _signInService;
    private readonly Mock<UserManager<AppUser>> _userManagerMock;
    private readonly Mock<SignInManager<AppUser>> _signInManagerMock;

    public SignInService_Test(Mock<SignInManager<AppUser>> signInManagerMock)
    {
        _userManagerMock = new Mock<UserManager<AppUser>>(
            new Mock<IUserStore<AppUser>>().Object,
            null!, null!, null!, null!, null!, null!, null!, null!);
        _signInManagerMock = new Mock<SignInManager<AppUser>>();

        _signInService = new SignInService(_userManagerMock.Object, _signInManagerMock.Object, null!);

    }


    [Fact]
    public async Task SignInAsync()
    {
        // Arrange
        var signInViewModel = new SignInViewModel
        {
            Email = "test@domain.com",
            Password = "Bytmig123!"
        };

        // Set up an expectation on the SignInManager mock to check for a specific email.
        _signInManagerMock
            .Setup(x => x.PasswordSignInAsync(
                It.Is<string>(email => email == signInViewModel.Email), // Verify email
                It.IsAny<string>(), // Ignore password for now
                It.IsAny<bool>(), It.IsAny<bool>())) // Ignore other parameters
            .Returns(Task.FromResult(Microsoft.AspNetCore.Identity.SignInResult.Success));

        // Act
        var result = await _signInService.LoginAsync(signInViewModel);

        // Assert
        Assert.True(result); // Assuming a successful login returns true.

        // Verify that PasswordSignInAsync was called with the expected email.
        _signInManagerMock.Verify(x => x.PasswordSignInAsync(signInViewModel.Email, It.IsAny<string>(), false, false), Times.Once);
    }
}
