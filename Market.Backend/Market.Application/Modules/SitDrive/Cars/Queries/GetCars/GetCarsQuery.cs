using Market.Application.Common;
using MediatR;

namespace Market.Application.Modules.SitDrive.Cars.Queries.GetCars;

public sealed record GetCarsQuery(
    PageRequest Paging,
    int? BranchId,
    int? ManufacturerId,
    int? CarModelId,
    int? YearFrom,
    int? YearTo,
    decimal? PriceFrom,
    decimal? PriceTo
) : IRequest<PageResult<CarListItemDto>>;