using Manero.Helpers.Services;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class SignInController : Controller
    {
        private readonly SignInService _signInService;

        public SignInController(SignInService signInService)
        {
            _signInService = signInService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _signInService.LoginAsync(model))
                    return RedirectToAction("Index", "Home");

                ModelState.AddModelError("", "Incorrect email or password");
            }


            return View(model);
        }
    }
}
