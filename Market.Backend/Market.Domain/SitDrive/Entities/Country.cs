using Market.Domain.Common;
using Market.Domain.SitDrive.Enums;

namespace Market.Domain.SitDrive.Entities;

public sealed class Country : BaseEntity, ITenant
{
    public int FirmId { get; set; }

    public string Name { get; set; } = string.Empty;
    public EntityStatus Status { get; set; } = EntityStatus.Active;

    //public ICollection<City> Cities { get; set; } = new List<City>();
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
}