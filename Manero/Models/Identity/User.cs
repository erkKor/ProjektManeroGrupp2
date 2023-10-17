using Manero.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Manero.Models.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? UploadProfileImage { get; set; }

        public ICollection<UserAdressEntity> Adresses { get; set; } = new HashSet<UserAdressEntity>();
    }
}
