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

        public SignUpService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
