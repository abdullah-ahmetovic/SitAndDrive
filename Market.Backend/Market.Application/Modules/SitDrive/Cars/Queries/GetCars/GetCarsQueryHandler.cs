using Market.Application.Abstractions;
using Market.Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.SitDrive.Cars.Queries.GetCars;

public sealed class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, PageResult<CarListItemDto>>
{
    private readonly IAppDbContext _db;

    public GetCarsQueryHandler(IAppDbContext db)
    {
        _db = db;
    }

    public async Task<PageResult<CarListItemDto>> Handle(GetCarsQuery request, CancellationToken ct)
    {
        // Base query
        var query = _db.Cars
            .AsNoTracking()
            .Include(x => x.Manufacturer)
            .Include(x => x.CarModel)
            .Include(x => x.Branch)
            .AsQueryable();

        // Filters
        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId.Value);

        if (request.ManufacturerId.HasValue)
            query = query.Where(x => x.ManufacturerId == request.ManufacturerId.Value);

        if (request.CarModelId.HasValue)
            query = query.Where(x => x.CarModelId == request.CarModelId.Value);

        if (request.YearFrom.HasValue)
            query = query.Where(x => x.Year >= request.YearFrom.Value);

        if (request.YearTo.HasValue)
            query = query.Where(x => x.Year <= request.YearTo.Value);

        if (request.PriceFrom.HasValue)
            query = query.Where(x => x.DailyPrice >= request.PriceFrom.Value);

        if (request.PriceTo.HasValue)
            query = query.Where(x => x.DailyPrice <= request.PriceTo.Value);

        // Project to DTO (after filters)
        var dtoQuery = query
            .OrderByDescending(x => x.Id)
            .Select(x => new CarListItemDto
            {
                Id = x.Id,
                LicensePlate = x.LicensePlate,
                Year = x.Year,
                PricePerDay = x.DailyPrice,
                Transmission = x.Transmission,

                ManufacturerId = x.ManufacturerId,
                ManufacturerName = x.Manufacturer.Name,

                CarModelId = x.CarModelId,
                CarModelName = x.CarModel.Name,

                BranchId = x.BranchId,
                BranchName = x.Branch.Name
            });

        // Paging via YOUR existing PageResult + PageRequest
        return await PageResult<CarListItemDto>.FromQueryableAsync(dtoQuery, request.Paging, ct, includeTotal: true);
    }
}