using Manero.Contexts;
using Manero.Helpers.Services;
using Manero.Models.Entities;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manero.Controllers
{
    [Authorize]
    public class EditAddressController : Controller
    {

        readonly DataContext _context;
        readonly AddressService _addressService;

        public EditAddressController(DataContext context, AddressService addressService)
        {
            _context = context;
            _addressService = addressService;
        }

        public async Task<IActionResult> Index(int? id = null)
        {
            if (await _addressService.FindAsync(id) is AdressEntity address)
                return View((EditAddressVM)address);
            else
                return View(new EditAddressVM());
        }

        [HttpPost]
        public async Task<IActionResult> Index(EditAddressVM view)
        {

            if (!ModelState.IsValid)
                return View(view);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity!.Name);
            if (user is null)
            {
                ModelState.AddModelError("", "Could not find user.");
                return View(view);
            }

            if ((view.Id.HasValue
                ? await _addressService.UpdateAsync(view)
                : await _addressService.AddAsync(view, user)))
                return RedirectToAction("Index", "myaddresses");
            else
            {
                ModelState.AddModelError("", "Something went wrong, please try again in a moment.");
                return View(view);
            }

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _addressService.RemoveAsync(id);
            return RedirectToAction("Index", "myaddresses");
        }

    }
}