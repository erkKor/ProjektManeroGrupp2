using Manero.Contexts;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manero.Controllers
{
    public class EditAddressController : Controller
    {

        readonly DataContext _context;

        public EditAddressController(DataContext context) =>
            _context = context;

        public async Task<IActionResult> Index(int id)
        {

            var address = await _context.Adresses.FirstOrDefaultAsync(a => a.Id == id);
            if (address is not null)
                return View(new EditAddressVM() { Id = address.Id, AdressName = address.AdressName, StreetName = address.StreetName, City = address.City, PostalCode = address.PostalCode });
            else
                return View(new EditAddressVM() { IsCreatingNew = true });

        }

        [HttpPost]
        public async Task<IActionResult> Index(EditAddressVM view)
        {

            return View(view);

        }

    }
}