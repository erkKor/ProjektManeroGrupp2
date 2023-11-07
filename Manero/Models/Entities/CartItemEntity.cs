using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities
{
    public class CartItemEntity
    {
        [Key]
        public int CartItemId { get; set; }

        [ForeignKey("ShoppingCartId")]
        public int ShoppingCartId { get; set; }
        public ShoppingCartEntity ShoppingCart { get; set; } = null!;

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; } 
        public int Quantity { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }

        
    }
}

