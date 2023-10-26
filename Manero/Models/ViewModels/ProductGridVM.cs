namespace Manero.Models.ViewModels
{
    public class ProductGridVM
    {
        public IEnumerable<string>? Categories { get; set; }
        public IEnumerable<ProductGridItemVM> GridItems { get; set; } = null!;

        public string? SearchTitle { get; set; } 
    }
}
