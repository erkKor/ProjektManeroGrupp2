using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class MyAddressesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}