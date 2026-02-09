using Market.Domain.Common;
using Market.Domain.SitDrive.Enums;

namespace Market.Domain.SitDrive.Entities;

public class Company : BaseEntity, ITenant
{
    public int FirmId { get; set; } // For tenant root, set FirmId = Id in seed.

    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public EntityStatus Status { get; set; }

    public ICollection<Branch> Branches { get; set; } = new List<Branch>();
}