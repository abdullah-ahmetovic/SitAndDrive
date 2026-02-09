using Market.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.SitDrive.Cars.Commands.PatchCar;

public sealed class PatchCarCommandHandler : IRequestHandler<PatchCarCommand, bool>
{
    private readonly IAppDbContext _db;

    public PatchCarCommandHandler(IAppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(PatchCarCommand request, CancellationToken ct)
    {
        var car = await _db.Cars.FirstOrDefaultAsync(x => x.Id == request.Id, ct);
        if (car is null) return false;

        var d = request.Data;

        // FK checks only if provided
        if (d.BranchId.HasValue && !await _db.Branches.AnyAsync(x => x.Id == d.BranchId.Value, ct))
            throw new InvalidOperationException("BranchId ne postoji.");

        if (d.ManufacturerId.HasValue && !await _db.Manufacturers.AnyAsync(x => x.Id == d.ManufacturerId.Value, ct))
            throw new InvalidOperationException("ManufacturerId ne postoji.");

        if (d.CarModelId.HasValue && !await _db.CarModels.AnyAsync(x => x.Id == d.CarModelId.Value, ct))
            throw new InvalidOperationException("CarModelId ne postoji.");

        // Unique checks only if changing LicensePlate/Vin
        if (d.LicensePlate is not null)
        {
            var plate = d.LicensePlate.Trim();
            if (plate.Length == 0) throw new InvalidOperationException("LicensePlate ne smije biti prazan.");

            var plateExists = await _db.Cars.AnyAsync(x =>
                x.Id != car.Id && x.FirmId == car.FirmId && x.LicensePlate == plate, ct);

            if (plateExists) throw new InvalidOperationException("LicensePlate već postoji za ovaj FirmId.");

            car.LicensePlate = plate;
        }

        if (d.Vin is not null)
        {
            var vin = d.Vin.Trim();
            if (vin.Length == 0) throw new InvalidOperationException("Vin ne smije biti prazan.");

            var vinExists = await _db.Cars.AnyAsync(x =>
                x.Id != car.Id && x.FirmId == car.FirmId && x.Vin == vin, ct);

            if (vinExists) throw new InvalidOperationException("Vin već postoji za ovaj FirmId.");

            car.Vin = vin;
        }

        // Apply only provided fields
        if (d.Color is not null)
        {
            var color = d.Color.Trim();
            if (color.Length == 0) throw new InvalidOperationException("Color ne smije biti prazan.");
            car.Color = color;
        }
        if (d.BranchId.HasValue)
        {
            if (d.BranchId.Value <= 0) throw new InvalidOperationException("BranchId mora biti > 0.");
            if (!await _db.Branches.AnyAsync(x => x.Id == d.BranchId.Value, ct))
                throw new InvalidOperationException("BranchId ne postoji.");
        }

        if (d.ManufacturerId.HasValue)
        {
            if (d.ManufacturerId.Value <= 0) throw new InvalidOperationException("ManufacturerId mora biti > 0.");
            if (!await _db.Manufacturers.AnyAsync(x => x.Id == d.ManufacturerId.Value, ct))
                throw new InvalidOperationException("ManufacturerId ne postoji.");
        }

        if (d.CarModelId.HasValue)
        {
            if (d.CarModelId.Value <= 0) throw new InvalidOperationException("CarModelId mora biti > 0.");
            if (!await _db.CarModels.AnyAsync(x => x.Id == d.CarModelId.Value, ct))
                throw new InvalidOperationException("CarModelId ne postoji.");
        }

        if (d.Transmission.HasValue) car.Transmission = d.Transmission.Value;

        if (d.Year.HasValue) car.Year = d.Year.Value;
        if (d.PowerKw.HasValue) car.PowerKw = d.PowerKw.Value;
        if (d.FuelConsumption.HasValue) car.FuelConsumption = d.FuelConsumption.Value;

        if (d.DailyPrice.HasValue) car.DailyPrice = d.DailyPrice.Value;
        if (d.Status.HasValue) car.Status = d.Status.Value;

        await _db.SaveChangesAsync(ct);
        return true;
    }
}