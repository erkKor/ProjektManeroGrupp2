using Manero.Models.Identity;
using Manero.Models.ViewModels;

namespace Manero.Tests;

public class AppUserTest
{
    [Fact]
    public void SignUpViewModel_Should_ConvertTo_AppUser()
    {
        // Arrange
        SignUpViewModel viewModel = new SignUpViewModel()
        {
            FirstName = "Test",
            LastName = "Testsson",
            Email = "test@domain.com",
        };

        // Act
        AppUser user = viewModel;

        // Assert
        Assert.NotNull(user);
        Assert.Equal(viewModel.FirstName, user.FirstName);
        Assert.Equal(viewModel.LastName, user.LastName);
        Assert.Equal(viewModel.Email, user.Email);
    }
}
