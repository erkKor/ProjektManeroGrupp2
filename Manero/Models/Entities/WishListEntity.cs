using Manero.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities
{
    public class WishListEntity
    {
        public int Id { get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<WishListItemEntity> WishListItems { get; set; } = new List<WishListItemEntity>();
    }
}
