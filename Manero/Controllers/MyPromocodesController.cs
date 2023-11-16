using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class MyPromocodesController : Controller
    {
        public IActionResult ClonePartial1(MyPromoViewModel model)
        {
            var clonedModel = new MyPromoViewModel
            {
                CompanyName_1 = model.CompanyName_1,
                DiscountPercentage_1 = model.DiscountPercentage_1,
                Month_1 = model.Month_1,
                VaildYear_1 = model.VaildYear_1
            };

            clonedModel.GenerateRandomCompanyName();
            clonedModel.GenerateRandomDiscountPercentage();
            clonedModel.GenerateRandomValidYearAndMonth();
            return PartialView("/Views/Partials/_MyPromocodesPartial_1.cshtml", clonedModel);
        }

        public IActionResult ClonePartial2(MyPromoViewModel model)
        {
            var clonedModel = new MyPromoViewModel
            {
                CompanyName_2 = model.CompanyName_2,
                DiscountPercentage_2 = model.DiscountPercentage_2,
                Month_2 = model.Month_2,
                VaildYear_2 = model.VaildYear_2
            };

            clonedModel.GenerateRandomCompanyName();
            clonedModel.GenerateRandomDiscountPercentage();
            clonedModel.GenerateRandomValidYearAndMonth();
            return PartialView("/Views/Partials/_MyPromocodesPartial_2.cshtml", clonedModel);
        }

        public IActionResult ClonePartial3(MyPromoViewModel model)
        {
            var clonedModel = new MyPromoViewModel
            {
                CompanyName_3 = model.CompanyName_3,
                DiscountPercentage_3 = model.DiscountPercentage_3,
                Month_3 = model.Month_3,
                VaildYear_3 = model.VaildYear_3
            };

            clonedModel.GenerateRandomCompanyName();
            clonedModel.GenerateRandomDiscountPercentage();
            clonedModel.GenerateRandomValidYearAndMonth();
            return PartialView("/Views/Partials/_MyPromocodesPartial_3.cshtml", clonedModel);
        }

        public IActionResult Index()
        {
            var model = new MyPromoViewModel();

            // Generate new promocode temporarily
            model.GenerateRandomCompanyName();
            model.GenerateRandomDiscountPercentage();
            model.GenerateRandomValidYearAndMonth();
            return View(model);
        }
    }
}