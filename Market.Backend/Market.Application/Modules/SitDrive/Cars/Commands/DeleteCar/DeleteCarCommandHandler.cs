using Market.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.SitDrive.Cars.Commands.DeleteCar;

public sealed class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, bool>
{
    private readonly IAppDbContext _db;

    public DeleteCarCommandHandler(IAppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(DeleteCarCommand request, CancellationToken ct)
    {
        var car = await _db.Cars.FirstOrDefaultAsync(x => x.Id == request.Id, ct);
        if (car is null) return false;

        _db.Cars.Remove(car);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}