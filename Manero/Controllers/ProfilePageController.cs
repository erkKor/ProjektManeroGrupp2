using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class ProfilePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
