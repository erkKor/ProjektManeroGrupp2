using Manero.Helpers.Services;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class WelcomeController : Controller
    {
        private readonly ICookieService _cookieService;

        public WelcomeController(ICookieService cookieService)
        {
            _cookieService = cookieService;
        }

        public IActionResult Index()
        {
            _cookieService.SetWelcomeCookie(HttpContext);
            return View();
        }
    }
}
