using Market.Domain.SitDrive.Enums;


namespace Market.Application.Modules.SitDrive.Cars.Queries.GetCars;

public sealed class CarListItemDto
{
    public int Id { get; init; }

    public string LicensePlate { get; init; } = default!;

    public int Year { get; init; }
    public decimal PricePerDay { get; init; }

    public CarTransmission Transmission { get; init; } = default!;

    public int ManufacturerId { get; init; }
    public string ManufacturerName { get; init; } = default!;

    public int CarModelId { get; init; }
    public string CarModelName { get; init; } = default!;

    public int BranchId { get; init; }
    public string BranchName { get; init; } = default!;
}