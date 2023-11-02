using Manero.Models.Entities;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Manero.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? UploadProfileImage { get; set; }

        public int? ProfileImageId { get; set; }
        public EditProfileVM EditProfileVM { get; set; }

        public ICollection<UserAdressEntity> Adresses { get; set; } = new HashSet<UserAdressEntity>();
    }
}
