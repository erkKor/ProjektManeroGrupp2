using Manero.Contexts;
using Manero.Models.Entities;
using System.Net.NetworkInformation;

namespace Manero.Helpers.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCartEntity>
    {
        private readonly DataContext _context;
        public ShoppingCartRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddShoppingCartWithItemsAsync(ShoppingCartEntity shoppingCart)
        {

            try
            {
                _context.Set<ShoppingCartEntity>().Add(shoppingCart);

                foreach (var item in shoppingCart.Items)
                {
                    _context.Set<CartItemEntity>().Add(item);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
             throw;
            }
        }

        public async Task UpdateShoppingCartWithItemsAsync(ShoppingCartEntity shoppingCart)
        {

            try
            {
                _context.Set<ShoppingCartEntity>().Update(shoppingCart);

                foreach (var item in shoppingCart.Items)
                {
                    _context.Set<CartItemEntity>().Update(item);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
