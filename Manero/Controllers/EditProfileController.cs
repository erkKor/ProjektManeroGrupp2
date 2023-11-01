using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class EditProfileController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EditProfileController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
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
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.UploadProfileImage.FileName;

                var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "profileimages");

                // Kontrollera om katalogen "profileimages" finns, annars skapa den.
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                var filePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.UploadProfileImage.CopyToAsync(stream);
                }

                // Spara filvägen i användarens profil i databasen.
                // Exempel: User.UploadProfileImage = "/profileimages/" + uniqueFileName;
                // Här behövs det implementera hur du kopplar bilden till användaren.

                return RedirectToAction("Index");
            }

            // Åtgärden om ingen bild valdes.
            // Du kan hantera det som passar dina behov.

            return View();
        }

    }
}
