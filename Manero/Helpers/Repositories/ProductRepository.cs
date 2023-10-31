using Manero.Contexts;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manero.Helpers.Repositories
{
    public class ProductRepository : Repository<ProductEntity>
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<ProductEntity>> GetAllWithCategoriesAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                    .ThenInclude(pc => pc.Category)
                .ToListAsync();
        }
    }

    public class ProductCategoryRepository : Repository<ProductCategoryEntity>
    {
        public ProductCategoryRepository(DataContext context) : base(context)
        {
        }
    }




    public class MockProductRepository : ProductRepository
    {
        public MockProductRepository(DataContext context) : base(context)
        {
        }
    }
}
