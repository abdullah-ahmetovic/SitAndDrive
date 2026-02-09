using Market.Domain.Common;

namespace Market.Domain.SitDrive.Entities;

public sealed class ReservationExtension : BaseEntity, ITenant
{
    public int FirmId { get; set; }

    public int ReservationId { get; set; }
    public Reservation Reservation { get; set; } = default!;

    public DateTime PreviousEndDate { get; set; }
    public DateTime ExtensionRequestedAt { get; set; }
    public int AdditionalDays { get; set; }
    public bool IsApproved { get; set; }
    public DateTime? ApprovedAtUtc { get; set; }
    public int? ApprovedByEmployeeId { get; set; }
    public Employee? ApprovedByEmployee { get; set; }
}