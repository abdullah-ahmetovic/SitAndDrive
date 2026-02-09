using Market.Domain.Common;

namespace Market.Domain.SitDrive.Entities;

public sealed class Reservation : BaseEntity, ITenant
{
    public int FirmId { get; set; }

    public int CarId { get; set; }
    public Car Car { get; set; } = default!;

    public DateTime ReservationDate { get; set; }
    public DateTime PlannedPickupDate { get; set; }

    public int DaysCount { get; set; }

    public bool IsApproved { get; set; }
    public DateTime? ApprovedAtUtc { get; set; }
    public int? ApprovedByEmployeeId { get; set; }
    public Employee? ApprovedByEmployee { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = default!;

    // 1:1 Invoice
    public Invoice? Invoice { get; set; }

    public ICollection<ReservationExtension> Extensions { get; set; } = new List<ReservationExtension>();
    public ICollection<CarDamage> Damages { get; set; } = new List<CarDamage>();
}