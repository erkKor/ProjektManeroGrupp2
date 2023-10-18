using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
