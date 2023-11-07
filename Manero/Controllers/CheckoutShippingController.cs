using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class CheckoutShippingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
