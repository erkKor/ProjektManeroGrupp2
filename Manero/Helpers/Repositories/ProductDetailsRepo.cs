using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Helpers.Repositories
{
    public class ProductDetailsRepo : Repository<ProductDetailsEntity>
    {
        public ProductDetailsRepo(DataContext context) : base(context)
        {
        }
    }
}
