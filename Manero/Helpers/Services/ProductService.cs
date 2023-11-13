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

     
    }
}
