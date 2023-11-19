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

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            // Ensure the user is authenticated
            if (user == null)
            {
                return RedirectToAction("Index", "SignIn");
            }

            // Retrieve the user's wishlist and associated items
            var wishlist = await _dbContext.WishLists
                .Include(w => w.WishListItems)
                .ThenInclude(item => item.Product) // Assuming Product is a navigation property in WishListItemEntity
                .FirstOrDefaultAsync(w => w.UserId == user.Id);

            if (wishlist == null)
            {
                // Wishlist not found, you can handle this case based on your requirements
                return NotFound();
            }

            // convert WishList to List<ProductEntity>

            var items = wishlist.WishListItems;
            var products = new List<ProductEntity>();
            foreach (var item in items)
            {
                var product = new ProductEntity()
                {
                    Id = item.ProductId,
                    Name = item.Product.Name,
                    Description = item.Product.Description,
                    Rating = item.Product.Rating,
                    Price = item.Product.Price,
                };
                products.Add(product);
            }

            // You can pass the wishlist to the view for rendering
            return View(products);
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

            // retrieve WishListItems

            List<WishListItemEntity> wishListItems = await _dbContext.WishListItems.Where(i => i.WishListId == wishList.Id).ToListAsync();

            // check if product already exists in wishList
            if(!wishListItems.Any(i => i.ProductId == productId)) 
            {
                var item = new WishListItemEntity
                {
                    ProductId = productId,
                    WishListId = wishList.Id
                };

                user.WishList.WishListItems.Add(item);

                await _dbContext.SaveChangesAsync();
            }

            

            return NoContent();

        }      
    }
}
