using Manero.Helpers.Services;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    [Authorize]
    public class MyAddressesController : Controller
    {

        readonly AddressService _service;

        public MyAddressesController(AddressService service) =>
            _service = service;

        public async Task<IActionResult> Index()
        {
            var addresses = await _service.FindAddressesForUserWithEmail(User.Identity!.Name!);
            return View(new MyAddressesVM() { Addresses = addresses });
        }

    }
}