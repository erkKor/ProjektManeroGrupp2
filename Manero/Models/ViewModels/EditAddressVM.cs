using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Manero.Models.Entities;

namespace Manero.Models.ViewModels
{
    public class EditAddressVM
    {

        public int? Id { get; set; }

        [Required, DisplayName("Name")]
        public string? AdressName { get; set; }

        [Required, DisplayName("Street name")]
        public string StreetName { get; set; } = null!;

        [Required, DisplayName("Postal code")]
        public string PostalCode { get; set; } = null!;

        [Required, DisplayName("City")]
        public string City { get; set; } = null!;

        public static implicit operator AdressEntity(EditAddressVM view)
        {

            var entity = new AdressEntity
            {
                City = view.City,
                PostalCode = view.PostalCode,
                AdressName = view.AdressName,
                StreetName = view.StreetName
            };

            if (view.Id.HasValue)
                entity.Id = view.Id.Value;

            return entity;

        }

    }
}