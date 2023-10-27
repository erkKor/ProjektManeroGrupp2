using Manero.Contexts;
using Manero.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace Manero.Helpers.Repositories
{
    public class SignUpRepo : Repository<AppUser>
    {
        public SignUpRepo(DataContext context) : base(context)
        {
        }
    }
}
