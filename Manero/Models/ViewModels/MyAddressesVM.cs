using Manero.Models.Entities;

namespace Manero.Models.ViewModels;

public class MyAddressesVM
{

    public IEnumerable<AdressEntity> Addresses { get; set; } = Enumerable.Empty<AdressEntity>();

}
