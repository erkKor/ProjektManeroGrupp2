using Manero.Helpers.Services;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly ProductDetailsService _productService;

        public ProductDetailsController(ProductDetailsService productDetailsService)
        {
            _productService = productDetailsService;
        }


        public async Task<IActionResult> Product(int id)
        {
            ViewData["Title"] = "Product Details";
            var product = await _productService.GetAsync(x => x.ProductId == id);
            return View(product);
        }
    }
}
