using Market.Domain.Common;
using Market.Domain.SitDrive.Enums;

namespace Market.Domain.SitDrive.Entities;

public sealed class Person : BaseEntity, ITenant
{
    public int FirmId { get; set; }

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }

    public EntityStatus Status { get; set; }

    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!; // do not store raw password
    public string PhoneNumber { get; set; } = default!;

    public Customer? Customer { get; set; }
    public Employee? Employee { get; set; }
}