using Market.Domain.Common;
using Market.Domain.SitDrive.Enums;

namespace Market.Domain.SitDrive.Entities;

public class Car : BaseEntity, ITenant
{
    public int FirmId { get; set; }
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; } = default!;
    public int BranchId { get; set; }
    public Branch Branch { get; set; } = default!;

    public int CarModelId { get; set; }
    public CarModel CarModel { get; set; } = default!;

    public string LicensePlate { get; set; } = default!;
    public string Vin { get; set; } = default!;
    public string Color { get; set; } = default!;
    public CarTransmission Transmission { get; set; }

    public int Year { get; set; }
    public double PowerKw { get; set; }
    public double FuelConsumption { get; set; }

    public decimal DailyPrice { get; set; }
    public EntityStatus Status { get; set; }

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public ICollection<CarDamage> Damages { get; set; } = new List<CarDamage>();
}