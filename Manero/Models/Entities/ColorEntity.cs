using System.ComponentModel.DataAnnotations;

namespace Manero.Models.Entities
{
    public class ColorEntity
    {
        [Key]
        public int ColorId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
    }

    public class ProductColor
    {
        public int ProductId { get; set; }
        public ProductDetailsEntity Product { get; set; } = null!;

        public int ColorId { get; set; }
        public ColorEntity Color { get; set; } = null!;
    }
}
