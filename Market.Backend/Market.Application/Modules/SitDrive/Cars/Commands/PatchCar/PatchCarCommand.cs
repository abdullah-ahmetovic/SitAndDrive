using MediatR;

namespace Market.Application.Modules.SitDrive.Cars.Commands.PatchCar;

public sealed record PatchCarCommand(int Id, PatchCarRequestDto Data) : IRequest<bool>;