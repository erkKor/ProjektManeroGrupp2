﻿using Manero.Models.Identity;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class EditProfileController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<AppUser> _userManager;

        public EditProfileController(IWebHostEnvironment hostingEnvironment, UserManager<AppUser> userManager) 
        {
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager; 
        }

        public IActionResult Index()
        {
            var model = new EditProfileVM(); // Skapa en instans av din modell
            return View(model); // Skicka modellen till vyn
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfileImage(EditProfileVM model)
        {
            if (model.UploadProfileImage != null && model.UploadProfileImage.Length > 0)
            {
                // Validera den uppladdade filen här (t.ex. filtyp, storlek, etc.)

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.UploadProfileImage.FileName;
                var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "profileimages");

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                var filePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.UploadProfileImage.CopyToAsync(stream);
                }

                // Uppdatera egenskapen i din modell med den nya filvägen
                model.ProfileImagePath = "/profileimages/" + uniqueFileName;

                // Använd RedirectToAction för att omdirigera till Index-åtgärden
                return RedirectToAction("Index", "EditProfile");
            }

            // Åtgärden om ingen bild valdes.
            // Du kan hantera det som passar dina behov.

            return View(model);
        }

    }
}
