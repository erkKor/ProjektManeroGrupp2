using Manero.Helpers.Services;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ProductService _productService;

        public CategoriesController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> SelectedCategory(string category)
        {

            var viewModel = new ProductGridVM
            {
                GridItems = await _productService.GetProductsByCategoryAsync(category)
            };

            return View(viewModel);

        }

        [HttpPost]
        public IActionResult Index(string category)
        {
            return RedirectToAction("SelectedCategory", category);
        }
    }
}
