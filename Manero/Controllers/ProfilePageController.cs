using Manero.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class ProfilePageController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public ProfilePageController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (!_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "SignIn");

            return View();
        }
    }
}
