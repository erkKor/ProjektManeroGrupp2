using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Manero.Models.Entities
{
    public class ProductDetailsEntity
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? Size { get; set; } = null!;
        public ICollection<ProductColor>? ProductColors { get; set; } = new List<ProductColor>();
        public int? Quantity { get; set; }

        public ICollection<ProductReviewEntity> ProductReviews { get; set; } = null!;

    }
}
