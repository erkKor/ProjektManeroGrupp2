using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Manero.Helpers.Services
{
    public interface IReviewService
    {
        Task<int> CreateAsync(ReviewViewModel reviewModel);
        Task AddProductReviewAsync(int productId, int reviewId);
        Task<List<ReviewEntity>> GetReviewsByProductIdAsync(int productId);
        Task<List<ReviewEntity>> GetLatestReviewsByProductIdAsync(int productId, int count);
    }

    public class ReviewService : IReviewService
    {

        private readonly DataContext _context;

        public ReviewService(DataContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(ReviewViewModel reviewModel)
        {

            ReviewEntity reviewEntity = reviewModel;

            _context.Reviews.Add(reviewEntity);
            await _context.SaveChangesAsync();

            return reviewEntity.ReviewId;

        }

        public async Task AddProductReviewAsync(int productId, int reviewId)
        {
            await _context.AddAsync(new ProductReviewEntity
            {
                ProductId = productId,
                ReviewId = reviewId
            });
            await _context.SaveChangesAsync();
        }

        public async Task<List<ReviewEntity>> GetReviewsByProductIdAsync(int productId)
        {
            var reviews = await _context.ProductDetails
                .Where(p => p.ProductId == productId)
                .SelectMany(p => p.ProductReviews)
                .Select(pr => pr.Review)
                .ToListAsync();
            return reviews;
        }

        public async Task<List<ReviewEntity>> GetLatestReviewsByProductIdAsync(int productId, int count)
        {
            var reviews = await _context.ProductDetails
                .Where(p => p.ProductId == productId)
                .SelectMany(p => p.ProductReviews)
                .OrderByDescending(pr => pr.Review.CreatedAt)
                .Select(pr => pr.Review)
                .Take(count)
                .ToListAsync();

            return reviews;
        }
    }

}
