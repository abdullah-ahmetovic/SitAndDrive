using Market.Application.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Market.API.Controllers.SitDrive;

[ApiController]
[Route("api/sitdrive/[controller]")]
public sealed class LookupsController : ControllerBase
{
    private readonly IAppDbContext _db;
    public LookupsController(IAppDbContext db) => _db = db;

    [AllowAnonymous]
    [HttpGet("branches")]
    public async Task<IActionResult> GetBranches(CancellationToken ct)
    {
        var items = await _db.Branches
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .Select(x => new { x.Id, x.Name })
            .ToListAsync(ct);

        return Ok(items);
    }

    [AllowAnonymous]
    [HttpGet("manufacturers")]
    public async Task<IActionResult> GetManufacturers(CancellationToken ct)
    {
        var items = await _db.Manufacturers
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .Select(x => new { x.Id, x.Name })
            .ToListAsync(ct);

        return Ok(items);
    }

    [AllowAnonymous]
    [HttpGet("car-models")]
    public async Task<IActionResult> GetCarModels([FromQuery] int? manufacturerId, CancellationToken ct)
    {
        var q = _db.CarModels.AsNoTracking().AsQueryable();

        if (manufacturerId.HasValue)
            q = q.Where(x => x.ManufacturerId == manufacturerId.Value);

        var items = await q
            .OrderBy(x => x.Id)
            .Select(x => new { x.Id, x.Name, x.ManufacturerId })
            .ToListAsync(ct);

        return Ok(items);
    }
}