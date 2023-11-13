namespace Manero.Models.Entities
{
    public class ProductReviewEntity
    {
        public int ProductId { get; set; }
        public ProductDetailsEntity ProductDetails { get; set; } = null!;

        public int ReviewId { get; set; }
        public ReviewEntity Review { get; set; } = null!;
    }
}
