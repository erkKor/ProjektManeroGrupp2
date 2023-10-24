using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
