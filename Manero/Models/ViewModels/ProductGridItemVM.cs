using Manero.Models.Entities;

namespace Manero.Models.ViewModels
{
    public class ProductGridItemVM
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
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
                Rating = product.Rating,
                Price = product.Price,
                ImageUrl = product.ImageUrl!
            };
        }
    }
}
