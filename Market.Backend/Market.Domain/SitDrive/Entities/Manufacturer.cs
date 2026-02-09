using Market.Domain.Common;

namespace Market.Domain.SitDrive.Entities;

public class Manufacturer : BaseEntity, ITenant
{
    public int FirmId { get; set; }

    public string Name { get; set; } = default!;

    public ICollection<CarModel> Models { get; set; } = new List<CarModel>();
}