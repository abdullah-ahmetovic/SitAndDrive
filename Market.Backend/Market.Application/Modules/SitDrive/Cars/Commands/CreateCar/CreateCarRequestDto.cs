using Market.Domain.SitDrive.Enums;

namespace Market.Application.Modules.SitDrive.Cars.Commands.CreateCar;

public sealed class CreateCarRequestDto
{
    public int FirmId { get; init; }

    public int ManufacturerId { get; init; }
    public int BranchId { get; init; }
    public int CarModelId { get; init; }

    public string LicensePlate { get; init; } = default!;
    public string Vin { get; init; } = default!;
    public string Color { get; init; } = default!;

    public CarTransmission Transmission { get; init; }

    public int Year { get; init; }
    public double PowerKw { get; init; }
    public double FuelConsumption { get; init; }

    public decimal DailyPrice { get; init; }
    public EntityStatus Status { get; init; } = EntityStatus.Active;
}