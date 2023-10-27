using Manero.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities
{

    [PrimaryKey(nameof(UserId), nameof(AdressId))]
    public class UserAdressEntity
    {
        public string UserId { get; set; } = null!;
        public AppUser User { get; set; } = null!;

        public int AdressId { get; set; }
        public AdressEntity Adress { get; set; } = null!;
    }

}
