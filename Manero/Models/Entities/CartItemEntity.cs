using System.ComponentModel.DataAnnotations;

namespace Manero.Models.Entities
{
    public class CartItemEntity
    {
        [Key]
        public int CartItemId { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCartEntity ShoppingCart { get; set; } = null!;


        public string Name { get; set; } = null!;
        public decimal Price { get; set; } 
        public int Quantity { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }

        
    }
}

