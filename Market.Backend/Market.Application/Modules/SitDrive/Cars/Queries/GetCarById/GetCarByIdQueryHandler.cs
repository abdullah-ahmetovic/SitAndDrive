using Market.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.SitDrive.Cars.Queries.GetCarById;

public sealed class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarDetailsDto?>
{
    private readonly IAppDbContext _db;

    public GetCarByIdQueryHandler(IAppDbContext db)
    {
        _db = db;
    }

    public async Task<CarDetailsDto?> Handle(GetCarByIdQuery request, CancellationToken ct)
    {
        return await _db.Cars
            .AsNoTracking()
            .Include(x => x.Manufacturer)
            .Include(x => x.CarModel)
            .Include(x => x.Branch)
            .Where(x => x.Id == request.Id)
            .Select(x => new CarDetailsDto
            {
                Id = x.Id,
                FirmId = x.FirmId,

                BranchId = x.BranchId,
                BranchName = x.Branch.Name,

                ManufacturerId = x.ManufacturerId,
                ManufacturerName = x.Manufacturer.Name,

                CarModelId = x.CarModelId,
                CarModelName = x.CarModel.Name,

                LicensePlate = x.LicensePlate,
                Vin = x.Vin,
                Color = x.Color,

                Transmission = x.Transmission,

                Year = x.Year,
                PowerKw = x.PowerKw,
                FuelConsumption = x.FuelConsumption,

                PricePerDay = x.DailyPrice,
                Status = x.Status
            })
            .FirstOrDefaultAsync(ct);
    }
}