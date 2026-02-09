using Market.Domain.SitDrive.Enums;

namespace Market.Application.Modules.SitDrive.Cars.Queries.GetCarById;

public sealed class CarDetailsDto
{
    public int Id { get; init; }

    public int FirmId { get; init; }

    public int BranchId { get; init; }
    public string BranchName { get; init; } = default!;

    public int ManufacturerId { get; init; }
    public string ManufacturerName { get; init; } = default!;

    public int CarModelId { get; init; }
    public string CarModelName { get; init; } = default!;
    public string LicensePlate { get; init; } = default!;
    public string Vin { get; init; } = default!;
    public string Color { get; init; } = default!;

    public CarTransmission Transmission { get; init; }

    public int Year { get; init; }
    public double PowerKw { get; init; }
    public double FuelConsumption { get; init; }

    public decimal PricePerDay { get; init; }

    public EntityStatus Status { get; init; }
}