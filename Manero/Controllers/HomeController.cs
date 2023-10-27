using Manero.Helpers.Services;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
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

            return View(viewModel);
        }
    }
}