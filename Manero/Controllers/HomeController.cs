using Manero.Helpers.Services;
using Manero.Models.Identity;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ProductService productService, UserManager<AppUser> userManager)
        {

            _productService = productService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //If the user have not seen the Welcome page they get redirected to that page
            if (!Request.Cookies.ContainsKey("hasSeenWelcome"))
            {
                return RedirectToAction("Index", "Welcome");
            }

            var viewModel = new HomeControllerVM
            {
                FeaturedProducts = new ProductGridVM
                {
                    GridItems = await _productService.GetProductsByCategoryAsync("Featured")
                },
                BestSellers = new ProductGridVM
                {
                    GridItems = await _productService.GetProductsByCategoryAsync("Best Seller")
                }
            };

            AppUser? user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                string AppUserFirstName = user.FirstName;
                ViewBag.FirstName = AppUserFirstName;
            }

            return View(viewModel);
        }
    }
}