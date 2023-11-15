using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    // This is what Johnnys working on
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
