using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
