using Market.Domain.SitDrive.Enums;

namespace Market.Application.Modules.SitDrive.Cars.Commands.PatchCar;

public sealed class PatchCarRequestDto
{
    public int? ManufacturerId { get; init; }
    public int? BranchId { get; init; }
    public int? CarModelId { get; init; }

    public string? LicensePlate { get; init; }
    public string? Vin { get; init; }
    public string? Color { get; init; }

    public CarTransmission? Transmission { get; init; }

    public int? Year { get; init; }
    public double? PowerKw { get; init; }
    public double? FuelConsumption { get; init; }

    public decimal? DailyPrice { get; init; }
    public EntityStatus? Status { get; init; }
}