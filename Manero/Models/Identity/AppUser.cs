using Manero.Models.Entities;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? UploadProfileImage { get; set; }
        public int? ShoppingCartId { get; set; }
        public virtual WishListEntity WishList { get; set; }
        public ICollection<UserAdressEntity> Adresses { get; set; } = new HashSet<UserAdressEntity>();


    }
}
