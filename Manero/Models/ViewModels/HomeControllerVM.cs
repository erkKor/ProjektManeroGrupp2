namespace Manero.Models.ViewModels
{
    public class HomeControllerVM
    {
        public ProductGridVM FeaturedProducts { get; set; } = null!;
        public ProductGridVM BestSellers { get; set; } = null!;
    }
}
