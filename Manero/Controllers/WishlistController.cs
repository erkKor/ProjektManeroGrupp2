using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
