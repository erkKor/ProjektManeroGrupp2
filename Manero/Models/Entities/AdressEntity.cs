namespace Manero.Models.Entities
{
    public class AdressEntity
    {
        public int Id { get; set; }
        public string? AdressName { get; set; }
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public ICollection<UserAdressEntity> Users { get; set; } = new HashSet<UserAdressEntity>();
    }
}
