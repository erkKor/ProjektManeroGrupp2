using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Manero.Models.Identity;

namespace Manero.Models.Entities
{
    public class ShoppingCartEntity
    {
        [Key]
        public int ShoppingCartId { get; set; }
        public virtual ICollection<CartItemEntity> Items { get; set; } = new List<CartItemEntity>();
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser AppUser { get; set; } 
    }
}
