using Market.Domain.Common;
using Market.Domain.SitDrive.Enums;

namespace Market.Domain.SitDrive.Entities;

public class Branch : BaseEntity, ITenant
{
    public int FirmId { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; } = default!;

    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public EntityStatus Status { get; set; }

    public ICollection<Car> Cars { get; set; } = new List<Car>();
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}