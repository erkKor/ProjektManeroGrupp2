using System.ComponentModel.DataAnnotations;

namespace Manero.Models.Entities
{
    public class ReviewEntity
    {

        [Key]
        public int ReviewId { get; set; }

        public string Text { get; set; } = null!;

        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<ProductReviewEntity> ProductReviews { get; set; } = null!;

    }
}
