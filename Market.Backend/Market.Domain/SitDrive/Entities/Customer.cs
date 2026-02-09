using Market.Domain.Common;
using System.Diagnostics.Metrics;

namespace Market.Domain.SitDrive.Entities;

public sealed class Customer : BaseEntity, ITenant
{
    public int FirmId { get; set; }

    public int PersonId { get; set; }
    public Person Person { get; set; } = default!;

    public DateTime AccountCreatedAt { get; set; }

    public string DriverLicenseNumber { get; set; } = default!;

    public int CountryId { get; set; } // DrzavaId
    public Country Country { get; set; } = default!;

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}