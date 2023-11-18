using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manero.Controllers
{
    public class WishlistController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _dbContext;

        public WishlistController(UserManager<AppUser> userManager, DataContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        // Action to add a product to the wishlist
        public async Task<IActionResult> AddToWishlist(int productId)
        {
            var user = await _userManager.GetUserAsync(User);

            // Ensure the user is authenticated
            if (user == null)
            {
                
                return RedirectToAction("Index", "SignIn");
            }


            // Retrieve the WishList 

            var wishList = await _dbContext.WishLists
                .Where(w => w.UserId == user.Id)
                .FirstOrDefaultAsync();

            var item = new WishListItemEntity
            {
                ProductId = productId,
                WishListId = wishList.Id
            };

            user.WishList.WishListItems.Add(item);

            await _dbContext.SaveChangesAsync();

            return NoContent();

        }

        // Action to view the wishlist
        public async Task<IActionResult> ViewWishlist()
        {
            var user = await _userManager.GetUserAsync(User);

            // Ensure the user is authenticated
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(user.WishList.WishListItems);
        }
    }
}
