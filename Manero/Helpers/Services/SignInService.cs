using Manero.Models.Identity;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Manero.Helpers.Services
{
   
    public class SignInService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public SignInService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> LoginAsync(SignInViewModel model)
        {
            var appUpser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (appUpser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(appUpser, model.Password, model.RememberMe, false);
                return result.Succeeded;
            }

            return false;
        }
    }
}
