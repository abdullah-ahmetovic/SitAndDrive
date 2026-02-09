using Market.Domain.Common;
using Market.Domain.SitDrive.Enums;

namespace Market.Domain.SitDrive.Entities;

public sealed class Employee : BaseEntity, ITenant
{
    public int FirmId { get; set; }

    public string NationalIdNumber { get; set; } = default!; // MaticniBroj

    public int PersonId { get; set; }
    public Person Person { get; set; } = default!;

    public int BranchId { get; set; }
    public Branch Branch { get; set; } = default!;

    public EntityStatus Status { get; set; }

    public ICollection<Reservation> ApprovedReservations { get; set; } = new List<Reservation>();
    public ICollection<ReservationExtension> ApprovedExtensions { get; set; } = new List<ReservationExtension>();
}