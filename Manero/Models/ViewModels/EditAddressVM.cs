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
                AdressName = view.AdressName,
                City = view.City,
                PostalCode = view.PostalCode,
                StreetName = view.StreetName
            };

            if (view.Id.HasValue)
                entity.Id = view.Id.Value;

            return entity;

        }

        public static implicit operator EditAddressVM(AdressEntity entity) =>
            new()
            {
                Id = entity.Id,
                AdressName = entity.AdressName,
                City = entity.City,
                PostalCode = entity.PostalCode,
                StreetName = entity.StreetName,
            };

    }
}