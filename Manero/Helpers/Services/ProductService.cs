using Manero.Contexts;
using Manero.Helpers.Repositories;
using Manero.Models.Entities;
using Manero.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manero.Helpers.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepo;
        private readonly DataContext _context;

        public ProductService( ProductRepository productRepo, DataContext context)
        {
            _productRepo = productRepo;
            _context = context;
        }

        public async Task<ProductGridItemVM> GetProductAsync(int id)
        {
            var product = await _productRepo.GetAsync(x => x.Id == id);
            return product;
        }

        public async Task<IEnumerable<ProductGridItemVM>> GetAllProductsAsync()
        {
            var products = await _productRepo.GetAllWithCategoriesAsync();

            return products.Select(p => new ProductGridItemVM
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Color = p.Color,
                Size = p.Size,
                Price = p.Price,
                Rating = p.Rating,
                ImageUrl = p.ImageUrl!,
                Category = p.Category.Select(pc => pc.Category.CategoryName).ToArray()
            });
        }

        public async Task<IEnumerable<ProductGridItemVM>> GetProductsByCategoryAsync(string category)
        {
            var products = await _productRepo.GetAllWithCategoriesAsync();
            return products.Where(p => p.Category.Any(pc => pc.Category.CategoryName.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0)).Select(p => new ProductGridItemVM
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Color = p.Color,
                Size = p.Size,
                Rating = p.Rating,
                Price = p.Price,
                ImageUrl = p.ImageUrl!,
                Category = p.Category.Select(pc => pc.Category.CategoryName).ToArray()
            });
        }


        //public async Task<IEnumerable<string>> GetProductCategoriesAsync()
        //{
        //    var categories = await _categoryService.GetCategoriesAsync();
        //    return categories.Select(c => c.Name);
        //}

        public async Task<IEnumerable<ProductDetailsEntity>> GetAllWithCategoriesAsync()
        {
            return await _context.ProductDetails
                .Include(p => p.Category)
                    .ThenInclude(pc => pc.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDetailsEntity>> GetAsync()
        {
            var products = await _context.ProductDetails.Include(x => x.Category).ThenInclude(x => x.Category).ToListAsync();
            return products;
        }

        public async Task<ProductDetailsEntity> GetAsync(Expression<Func<ProductDetailsEntity, bool>> expression)
        {
            var product = await _context.ProductDetails.Include(x => x.Category).ThenInclude(x => x.Category).FirstOrDefaultAsync(expression);
            return product!;

        }
    }
}
