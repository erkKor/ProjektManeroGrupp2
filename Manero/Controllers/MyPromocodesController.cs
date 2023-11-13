using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class MyPromocodesController : Controller
    {
        public IActionResult Index(MyPromoViewModel model)
        {

            // Generate new promocode temporary

            model.GenerateRandomCompanyName();
            model.GenerateRandomDiscountPercentage();
            model.GenerateRandomValidYearAndMonth();
            return View(model);
        }
    }
}