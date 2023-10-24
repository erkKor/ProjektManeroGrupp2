using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class FilterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}