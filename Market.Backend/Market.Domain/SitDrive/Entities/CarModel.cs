using Market.Domain.Common;

namespace Market.Domain.SitDrive.Entities;

public class CarModel : BaseEntity, ITenant
{
    public int FirmId { get; set; }

    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; } = default!;

    public string Name { get; set; } = default!;

    public ICollection<Car> Cars { get; set; } = new List<Car>();
}