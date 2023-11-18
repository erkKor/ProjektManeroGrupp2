using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Models.Identity;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manero.Helpers.Services
{
    public class SignUpService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _dbContext;

        public SignUpService(UserManager<AppUser> userManager, DataContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        // Check if email already exists
        public async Task<bool> ExistsAsync(Expression<Func<AppUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);
        }

        // Create User
        public async Task<bool> SignUpAsync(SignUpViewModel model)
        {
            try
            {
                await _userManager.CreateAsync(model, model.Password);
                var addedUser = await _userManager.FindByEmailAsync(model.Email);

                var wishList = new WishListEntity
                {
                    UserId = addedUser.Id
                };

                await _dbContext.WishLists.AddAsync(wishList);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();
                Console.Write("SUCCESS!");
                return true;
            }
            catch
            {
                Console.WriteLine("faaail...");
                return false;
            }
        }
    }
}
