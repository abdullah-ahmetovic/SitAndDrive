using Market.Domain.Common;
using Market.Domain.SitDrive.Enums;

namespace Market.Domain.SitDrive.Entities;

public sealed class CarDamage : BaseEntity, ITenant
{
    public int FirmId { get; set; }

    public int CarId { get; set; }
    public Car Car { get; set; } = default!;

    public int? ReservationId { get; set; } // nullable -> internal damage / service case
    public Reservation? Reservation { get; set; }

    public DateTime ReportedAt { get; set; }

    public EntityStatus Status { get; set; }

    public string Description { get; set; } = default!;
}