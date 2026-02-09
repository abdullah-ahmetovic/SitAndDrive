using MediatR;

namespace Market.Application.Modules.SitDrive.Cars.Commands.UpdateCar;

public sealed record UpdateCarCommand(int Id, UpdateCarRequestDto Data) : IRequest<bool>;