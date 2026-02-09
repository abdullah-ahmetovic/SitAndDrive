using Market.Domain.Common;
using Market.Domain.SitDrive.Enums;
using System.Transactions;

namespace Market.Domain.SitDrive.Entities;

public sealed class Invoice : BaseEntity, ITenant
{
    public int FirmId { get; set; }

    public int ReservationId { get; set; }
    public Reservation Reservation { get; set; } = default!;

    public decimal BasePrice { get; set; }
    public int DaysUsed { get; set; }
    public decimal Discount { get; set; }

    public bool IsClosed { get; set; }
    public decimal TotalPrice { get; set; }

    public DateTime IssuedAt { get; set; }

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}