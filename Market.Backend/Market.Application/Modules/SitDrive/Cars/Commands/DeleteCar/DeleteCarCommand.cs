using MediatR;

namespace Market.Application.Modules.SitDrive.Cars.Commands.DeleteCar;

public sealed record DeleteCarCommand(int Id) : IRequest<bool>;