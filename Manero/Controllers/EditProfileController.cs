using Manero.Models.Identity;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class EditProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public EditProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfileImage(EditProfileVM model)
        {
            if (model.UploadProfileImage != null && model.UploadProfileImage.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await model.UploadProfileImage.CopyToAsync(stream);
                    var image = new EditProfileVM
                    {
                        FileName = model.UploadProfileImage.FileName,
                        ImageData = stream.ToArray()
                    };

                    // Lägg till bilden i databasen och koppla den till användaren
                    var user = await _userManager.GetUserAsync(User);
                    user.EditProfileVM = image;
                    await _userManager.UpdateAsync(user);

                    // Alternativt kan du använda din Repository-klass istället för userManager
                    // var user = await userManager.GetUserAsync(User);
                    // await repository.UpdateAsync(user);
                }
            }

            return RedirectToAction("Index");
        }

    }
}
