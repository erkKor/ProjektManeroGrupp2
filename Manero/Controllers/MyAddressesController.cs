using Manero.Contexts;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manero.Controllers
{
    public class MyAddressesController : Controller
    {

        DataContext _context;

        public MyAddressesController(DataContext context) =>
            _context = context;

        public async Task<IActionResult> Index()
        {

            //TODO: User should not be able to modify all addresses on server, fix this once login is fixed

            var addresses = await _context.Adresses.ToArrayAsync();
            return View(new MyAddressesVM() { Addresses = addresses });

        }

    }
}