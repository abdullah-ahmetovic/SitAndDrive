using Market.Application.Abstractions;
using Market.Domain.SitDrive.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.SitDrive.Cars.Commands.CreateCar;

public sealed class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, int>
{
    private readonly IAppDbContext _db;

    public CreateCarCommandHandler(IAppDbContext db)
    {
        _db = db;
    }

    public async Task<int> Handle(CreateCarCommand request, CancellationToken ct)
    {
        var d = request.Data;

        if (string.IsNullOrWhiteSpace(d.LicensePlate))
            throw new InvalidOperationException("LicensePlate je obavezan.");

        if (string.IsNullOrWhiteSpace(d.Vin))
            throw new InvalidOperationException("Vin je obavezan.");

        if (string.IsNullOrWhiteSpace(d.Color))
            throw new InvalidOperationException("Color je obavezan.");

        // FK existence checks
        if (!await _db.Branches.AnyAsync(x => x.Id == d.BranchId, ct))
            throw new InvalidOperationException("BranchId ne postoji.");

        if (!await _db.Manufacturers.AnyAsync(x => x.Id == d.ManufacturerId, ct))
            throw new InvalidOperationException("ManufacturerId ne postoji.");

        if (!await _db.CarModels.AnyAsync(x => x.Id == d.CarModelId, ct))
            throw new InvalidOperationException("CarModelId ne postoji.");

        // Unique checks (FirmId + LicensePlate) and (FirmId + Vin)
        if (await _db.Cars.AnyAsync(x => x.FirmId == d.FirmId && x.LicensePlate == d.LicensePlate, ct))
            throw new InvalidOperationException("LicensePlate već postoji za ovaj FirmId.");

        if (await _db.Cars.AnyAsync(x => x.FirmId == d.FirmId && x.Vin == d.Vin, ct))
            throw new InvalidOperationException("Vin već postoji za ovaj FirmId.");

        var car = new Car
        {
            FirmId = d.FirmId,
            BranchId = d.BranchId,
            ManufacturerId = d.ManufacturerId,
            CarModelId = d.CarModelId,
            LicensePlate = d.LicensePlate.Trim(),
            Vin = d.Vin.Trim(),
            Color = d.Color.Trim(),
            Transmission = d.Transmission,
            Year = d.Year,
            PowerKw = d.PowerKw,
            FuelConsumption = d.FuelConsumption,
            DailyPrice = d.DailyPrice,
            Status = d.Status,
            IsDeleted = false
        };

        _db.Cars.Add(car);
        await _db.SaveChangesAsync(ct);

        return car.Id;
    }
}