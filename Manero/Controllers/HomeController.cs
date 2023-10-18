using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //If the user have not seen the Welcome page they get redirected to that page
            if (!Request.Cookies.ContainsKey("hasSeenWelcome"))
            {
                return RedirectToAction("Index", "Welcome");
            }
            return View();
        }
    }
}