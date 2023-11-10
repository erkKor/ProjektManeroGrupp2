using Manero.Contexts;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manero.Controllers
{
    [Authorize]
    public class MyAddressesController : Controller
    {

        readonly DataContext _context;

        public MyAddressesController(DataContext context) =>
            _context = context;

        public async Task<IActionResult> Index()
        {

            var user = await _context.Users.Include(u => u.Adresses).ThenInclude(a => a.Adress).FirstOrDefaultAsync(u => u.Email == User.Identity!.Name);
            var addresses = user!.Adresses.Select(a => a.Adress).ToArray();
            return View(new MyAddressesVM() { Addresses = addresses });

        }

    }
}