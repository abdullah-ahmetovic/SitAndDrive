using Market.Domain.Common;
using Market.Domain.SitDrive.Enums;

namespace Market.Domain.SitDrive.Entities;

public sealed class Transaction : BaseEntity, ITenant
{
    public int FirmId { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = default!;

    public decimal Amount { get; set; }
    public DateTime PaidAt { get; set; }

    public long ApprovalNumber { get; set; } // BrojOdobrenja

    public PaymentMethod PaymentMethod { get; set; }
}