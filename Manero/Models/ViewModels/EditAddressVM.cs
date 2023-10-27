using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Manero.Models.ViewModels
{
    public class EditAddressVM
    {

        public bool IsCreatingNew { get; set; }

        public int Id { get; set; }

        [Required, DisplayName("Name")]
        public string? AdressName { get; set; }

        [Required, DisplayName("Street name")]
        public string StreetName { get; set; } = null!;

        [Required, DisplayName("Postal code")]
        public string PostalCode { get; set; } = null!;

        [Required, DisplayName("City")]
        public string City { get; set; } = null!;

    }
}