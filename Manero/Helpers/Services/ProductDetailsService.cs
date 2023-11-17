using Manero.Contexts;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manero.Helpers.Services
{

    public interface IProductDetailsService
    {
        Task<IEnumerable<ProductDetailsEntity>> GetAllWithCategoriesAsync();
        Task<IEnumerable<ProductDetailsEntity>> GetAsync();
        Task<ProductDetailsEntity> GetAsync(Expression<Func<ProductDetailsEntity, bool>> expression);
    }

    public class ProductDetailsService : IProductDetailsService

    {
        private readonly DataContext _context;

        public ProductDetailsService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDetailsEntity>> GetAllWithCategoriesAsync()
        {
            return await _context.ProductDetails
            .ToListAsync();
        }

        public async Task<IEnumerable<ProductDetailsEntity>> GetAsync()
        {
            var products = await _context.ProductDetails.ToListAsync();
            return products;
        }

        public async Task<ProductDetailsEntity> GetAsync(Expression<Func<ProductDetailsEntity, bool>> expression)
        {
            var product = await _context.ProductDetails.FirstOrDefaultAsync(expression);
            return product!;

        }
    }
}