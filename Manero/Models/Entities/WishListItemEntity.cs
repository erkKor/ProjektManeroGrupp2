namespace Manero.Models.Entities
{
    public class WishListItemEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public int WishListId { get; set; }
        public virtual WishListEntity WishList { get; set; }
    }
}
