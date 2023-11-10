using Manero.Contexts;
using Manero.Helpers.Services;
using Manero.Models.Entities;
using Manero.Models.Identity;
using Manero.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Manero.Tests.Addresses;

public class AddressServiceTests
{

    #region EditAddressVM

    [Theory]
    [InlineData(new object[] { null! })] //Create
    [InlineData(new object[] { 200 })]   //Modify
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

    #endregion
    #region AddressService

    public AppUser User { get; } = new() { Id = "1", UserName = "test user", Email = "test@test.com" };

    readonly DataContext context;
    readonly AddressService service;

    public AddressServiceTests()
    {
        context = new(new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
        service = new(context);
    }

    [Fact]
    public async void AddAddress()
    {

        var view = new EditAddressVM() { AdressName = "test", City = "town", PostalCode = "12345", StreetName = "street 2" };

        var returnValue = await service.AddAsync(view, User);

        var item = context.Adresses.LastOrDefault();
        var proxyItem = context.UserAdresses.LastOrDefault();

        Assert.True(returnValue);
        Assert.NotNull(item);
        Assert.NotNull(proxyItem);

        Assert.True(item.Id != 0);
        Assert.Equal(view.AdressName, item.AdressName);
        Assert.Equal(view.StreetName, item.StreetName);
        Assert.Equal(view.PostalCode, item.PostalCode);
        Assert.Equal(view.City, item.City);

        Assert.Equal(User.Id, proxyItem.UserId);
        Assert.Equal(item.Id, proxyItem.AdressId);

    }

    [Fact]
    public async void EditAddress()
    {

        var addView = new EditAddressVM() { AdressName = "test", City = "town", PostalCode = "12345", StreetName = "street 2" };

        await service.AddAsync(addView, User);

        var item = context.Adresses.Last();

        var updateView = new EditAddressVM() { Id = item.Id, AdressName = "Home", City = "other town", PostalCode = "123453", StreetName = "street 3" };

        await service.UpdateAsync(updateView);
        item = await context.Adresses.FirstOrDefaultAsync(a => a.Id == updateView.Id);

        Assert.NotNull(item);
        Assert.Equal(updateView.Id, item.Id);
        Assert.Equal(updateView.AdressName, item.AdressName);
        Assert.Equal(updateView.StreetName, item.StreetName);
        Assert.Equal(updateView.PostalCode, item.PostalCode);
        Assert.Equal(updateView.City, item.City);

        Assert.NotEqual(addView.AdressName, item.AdressName);
        Assert.NotEqual(addView.StreetName, item.StreetName);
        Assert.NotEqual(addView.PostalCode, item.PostalCode);
        Assert.NotEqual(addView.City, item.City);

    }

    [Fact]
    public async void RemoveAddress()
    {

        var view = new EditAddressVM() { AdressName = "test", City = "town", PostalCode = "12345", StreetName = "street 2" };

        await service.AddAsync(view, User);

        var item = context.Adresses.Last();
        Assert.NotNull(item);
        var id = item.Id;

        await service.RemoveAsync(item.Id);

        item = await context.Adresses.FirstOrDefaultAsync(a => a.Id == id);
        Assert.Null(item);

        var proxyItem = await context.UserAdresses.FirstOrDefaultAsync(a => a.AdressId == id);
        Assert.Null(proxyItem);

    }

    #endregion

}
