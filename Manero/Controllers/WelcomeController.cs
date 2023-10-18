using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
