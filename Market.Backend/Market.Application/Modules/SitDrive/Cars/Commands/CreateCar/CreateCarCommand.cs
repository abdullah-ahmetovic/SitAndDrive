using MediatR;

namespace Market.Application.Modules.SitDrive.Cars.Commands.CreateCar;

public sealed record CreateCarCommand(CreateCarRequestDto Data) : IRequest<int>;