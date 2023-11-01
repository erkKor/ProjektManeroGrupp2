using Manero.Contexts;
using Manero.Helpers.Services;
using Manero.Models.Entities;
using Manero.Models.Identity;
using Manero.Models.ViewModels;
using Moq;
using Moq.EntityFrameworkCore;

namespace Manero.Tests.Addresses;

public class AddressTests
{

    [Theory]
    [InlineData(new object[] { 200 })]
    [InlineData(new object[] { null! })]
    public static void ViewModel_Should_Be_Castable_To_AdressEntity(int? id)
    {

        var view = new EditAddressVM()
        {
            Id = id,
            AdressName = "Name",
            StreetName = "Street 1",
            PostalCode = "12345",
            City = "Town",
        };

        var entity = (AdressEntity)view;

        Assert.NotNull(entity);
        Assert.IsType<AdressEntity>(entity);
        Assert.Equal(view.AdressName, entity.AdressName);
        Assert.Equal(view.StreetName, entity.StreetName);
        Assert.Equal(view.PostalCode, entity.PostalCode);
        Assert.Equal(view.City, entity.City);

        //I'm re-using same view model for both creating an address and modifying one,
        //the difference is whatever int? id, has a value or not 
        if (view.Id.HasValue)
            Assert.Equal(view.Id, entity.Id);
        else
            Assert.Equal(default, entity.Id);

    }

}

public class AddressServiceTests
{

    public AppUser User { get; } = new() { Id = "1", UserName = "test user", Email = "test@test.com" };

    public List<AdressEntity> Addresses { get; } = new();
    public List<UserAdressEntity> UserAddresses { get; } = new();

    readonly Mock<IDataContext> context;
    readonly AddressService service;

    public AddressServiceTests()
    {

        context = new();
        service = new(context.Object);

        context.Setup(c => c.Adresses).ReturnsDbSet(Addresses);
        context.Setup(c => c.UserAdresses).ReturnsDbSet(UserAddresses);

    }

    [Fact]
    public void AddAddress()
    {

        var view = new EditAddressVM() { AdressName = "test", City = "town", PostalCode = "12345", StreetName = "street 2" };

        var returnValue = service.Add(view, User);

        var item = Addresses.LastOrDefault();
        var item2 = UserAddresses.LastOrDefault();

        Assert.True(returnValue);
        Assert.NotNull(item);
        Assert.NotNull(item2);

        Assert.True(item.Id != 0);
        Assert.Equal(view.AdressName, item.AdressName);
        Assert.Equal(view.StreetName, item.StreetName);
        Assert.Equal(view.PostalCode, item.PostalCode);
        Assert.Equal(view.City, item.City);

        Assert.Equal(User.Id, item2.UserId);
        Assert.Equal(item.Id, item2.AdressId);

    }

    public void EditAddress()
    {

    }

    public void RemoveAddress()
    {

    }

}
