using Manero.Helpers.Services;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class SignUpController : Controller
    {
        private readonly SignUpService _signUpService;

        public SignUpController(SignUpService signUpService)
        {
            _signUpService = signUpService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignUpViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if(await _signUpService.ExistsAsync(x => x.Email == viewModel.Email))
                {
                    ModelState.AddModelError("", "User with the same Email already exists");
                    return View(viewModel);
                }

                if (await _signUpService.SignUpAsync(viewModel))
                    return RedirectToAction("AccountCreated", "SignUp");
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All inputs are required");
            }

            return View(viewModel);
        }

        public IActionResult AccountCreated()
        {
            return View();
        }
    }
}
