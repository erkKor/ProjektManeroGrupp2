using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class MyPromocodesAddController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MyPromoViewModel model)
        {  
            return RedirectToAction("index", "Mypromocodes", model);
        }
    }
}
