namespace Manero.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Size { get; set; }
        public string? Color { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
