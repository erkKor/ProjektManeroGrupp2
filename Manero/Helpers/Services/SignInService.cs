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
        private readonly ShoppingCartService _cartService;

        public SignInService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ShoppingCartService cartService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cartService = cartService;
        }

        public async Task<bool> LoginAsync(SignInViewModel model)
        {
            var appUpser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (appUpser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(appUpser, model.Password, model.RememberMe, false);
                if(result.Succeeded)
                {
                    await _cartService.SaveCartToDB(appUpser.Id);
                }
                return result.Succeeded;
            }

            return false;
        }
    }
}
