using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Models.Identity;
using Manero.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Manero.Helpers.Services;

public class AddressService
{

    private readonly DataContext _context;

    public AddressService(DataContext context) =>
        _context = context;

    public async Task<AdressEntity?> FindAsync(int? id) =>
        id is not null
        ? await _context.Adresses.FirstOrDefaultAsync(a => a.Id == id)
        : null;

    public async Task<bool> AddAsync(EditAddressVM view, AppUser user)
    {

        if (user is not null)
        {

            var entity = (AdressEntity)view;
            await _context.Adresses.AddAsync(entity);
            await _context.SaveChangesAsync();

            var proxy = new UserAdressEntity() { UserId = user.Id, AdressId = entity.Id };
            await _context.UserAdresses.AddAsync(proxy);
            await _context.SaveChangesAsync();

            return true;

        }
        else
            return false;

    }

    public async Task<bool> UpdateAsync(EditAddressVM view)
    {

        if (await FindAsync(view.Id) is AdressEntity address)
        {
            address.StreetName = view.StreetName;
            address.City = view.City;
            address.AdressName = view.AdressName;
            address.PostalCode = view.PostalCode;
            await _context.SaveChangesAsync();
            return true;
        }
        else
            return false;

    }

    public async Task<bool> RemoveAsync(int id)
    {

        if (await FindAsync(id) is AdressEntity address)
        {
            _context.Adresses.Remove(address);
            await _context.SaveChangesAsync();
            return true;
        }
        else
            return false;

    }

    public async Task<IEnumerable<AdressEntity>> FindAddressesForUserWithEmail(string email)
    {
        var user = await _context.Users.Include(u => u.Adresses).ThenInclude(a => a.Adress).FirstOrDefaultAsync(u => u.Email == email);
        var addresses = user!.Adresses.Select(a => a.Adress).ToArray();
        return addresses;
    }

}
