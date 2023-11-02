using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Helpers.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCartEntity>
    {
        public ShoppingCartRepository(DataContext context) : base(context)
        {
        }
    }

    public class CartItemRepository : Repository<CartItemEntity>
    {
        public CartItemRepository(DataContext context) : base(context)
        {
        }
    }
}
