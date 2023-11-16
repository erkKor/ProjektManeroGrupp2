using Manero.Contexts;
using Manero.Helpers.Services;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly ProductDetailsService _productService;
        readonly DataContext _context;

        public ProductDetailsController(ProductDetailsService productDetailsService, DataContext context)
        {
            _productService = productDetailsService;
            _context = context;
        }


        public async Task<IActionResult> Product(int id)
        {
            ViewData["Title"] = "Product Details";
            var product = await _productService.GetAsync(x => x.ProductId == id);
            return View(product);
        }
    }
}
