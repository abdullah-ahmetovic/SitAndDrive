using MediatR;

namespace Market.Application.Modules.SitDrive.Cars.Queries.GetCarById;

public sealed record GetCarByIdQuery(int Id) : IRequest<CarDetailsDto?>;