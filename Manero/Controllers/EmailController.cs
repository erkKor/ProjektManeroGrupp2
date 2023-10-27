using Manero.Models;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailModel model)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("SignIn", "Account");
            }

            return View("Index", model);
        }
    }
}
