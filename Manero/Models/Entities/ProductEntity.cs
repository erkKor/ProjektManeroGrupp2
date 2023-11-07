using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Size { get; set; } 
        public string? Color { get; set; }
        public string? Description { get; set; }
        public int Rating { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<ProductCategoryEntity> Category { get; set; } = null!;
    }
}
