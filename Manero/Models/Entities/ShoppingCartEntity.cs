using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Manero.Models.Identity;

namespace Manero.Models.Entities
{
    public class ShoppingCartEntity
    {
        [Key]
        public int ShoppingCartId { get; set; }
        public virtual ICollection<CartItemEntity> Items { get; set; } = null!;
        public Guid UserId { get; set; }

        [ForeignKey("Id")]
        public AppUser User { get; set; } = null!;
    }
}
