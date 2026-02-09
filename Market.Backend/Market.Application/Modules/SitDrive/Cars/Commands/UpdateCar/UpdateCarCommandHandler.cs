using Market.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.SitDrive.Cars.Commands.UpdateCar;

public sealed class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, bool>
{
    private readonly IAppDbContext _db;

    public UpdateCarCommandHandler(IAppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(UpdateCarCommand request, CancellationToken ct)
    {
        var car = await _db.Cars.FirstOrDefaultAsync(x => x.Id == request.Id, ct);
        if (car is null) return false;

        var d = request.Data;

        if (string.IsNullOrWhiteSpace(d.LicensePlate))
            throw new InvalidOperationException("LicensePlate je obavezan.");

        if (string.IsNullOrWhiteSpace(d.Vin))
            throw new InvalidOperationException("Vin je obavezan.");

        if (string.IsNullOrWhiteSpace(d.Color))
            throw new InvalidOperationException("Color je obavezan.");

        // FK checks
        if (!await _db.Branches.AnyAsync(x => x.Id == d.BranchId, ct))
            throw new InvalidOperationException("BranchId ne postoji.");

        if (!await _db.Manufacturers.AnyAsync(x => x.Id == d.ManufacturerId, ct))
            throw new InvalidOperationException("ManufacturerId ne postoji.");

        if (!await _db.CarModels.AnyAsync(x => x.Id == d.CarModelId, ct))
            throw new InvalidOperationException("CarModelId ne postoji.");

        // Unique checks within firm
        if (await _db.Cars.AnyAsync(x => x.Id != car.Id && x.FirmId == car.FirmId && x.LicensePlate == d.LicensePlate, ct))
            throw new InvalidOperationException("LicensePlate već postoji za ovaj FirmId.");

        if (await _db.Cars.AnyAsync(x => x.Id != car.Id && x.FirmId == car.FirmId && x.Vin == d.Vin, ct))
            throw new InvalidOperationException("Vin već postoji za ovaj FirmId.");

        car.BranchId = d.BranchId;
        car.ManufacturerId = d.ManufacturerId;
        car.CarModelId = d.CarModelId;

        car.LicensePlate = d.LicensePlate.Trim();
        car.Vin = d.Vin.Trim();
        car.Color = d.Color.Trim();

        car.Transmission = d.Transmission;

        car.Year = d.Year;
        car.PowerKw = d.PowerKw;
        car.FuelConsumption = d.FuelConsumption;

        car.DailyPrice = d.DailyPrice;
        car.Status = d.Status;

        await _db.SaveChangesAsync(ct);
        return true;
    }
}