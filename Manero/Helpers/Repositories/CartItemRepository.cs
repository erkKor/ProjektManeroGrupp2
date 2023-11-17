using Manero.Contexts;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manero.Helpers.Repositories
{
    public class CartItemRepository : Repository<CartItemEntity>
    {
        private readonly DataContext _context;
        public CartItemRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CartItemEntity>> GetAllByShoppingCartIdAsync(int id)
        {
            return await _context.CartItems
                .Where(x => x.ShoppingCartId == id)
                .ToListAsync();
        }

    }
}
