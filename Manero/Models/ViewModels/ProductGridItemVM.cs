using Manero.Models.Entities;

namespace Manero.Models.ViewModels
{
    public class ProductGridItemVM
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public string? Size { get; set; }
        public string? Color { get; set; }
        public string? Description { get; set; }
        public int Rating { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;

        public string[] Category { get; set; } = null!;

        public static implicit operator ProductGridItemVM(ProductEntity product)
        {
            return new ProductGridItemVM
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Color = product.Color,
                Size = product.Size,
                Rating = product.Rating,
                Price = product.Price,
                ImageUrl = product.ImageUrl!
            };
        }
    }
}
