using Market.Application.Common;
using Market.Application.Modules.SitDrive.Cars.Commands.CreateCar;
using Market.Application.Modules.SitDrive.Cars.Commands.DeleteCar;
using Market.Application.Modules.SitDrive.Cars.Commands.PatchCar;
using Market.Application.Modules.SitDrive.Cars.Commands.UpdateCar;
using Market.Application.Modules.SitDrive.Cars.Queries.GetCarById;
using Market.Application.Modules.SitDrive.Cars.Queries.GetCars;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers.SitDrive;

[ApiController]
[Route("api/sitdrive/[controller]")]
public sealed class CarsController : ControllerBase
{
    private readonly IMediator _mediator;
    public CarsController(IMediator mediator) => _mediator = mediator;
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<PageResult<CarListItemDto>>> GetCars(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] bool includeTotal = true,
        [FromQuery] int? branchId = null,
        [FromQuery] int? manufacturerId = null,
        [FromQuery] int? carModelId = null,
        [FromQuery] int? yearFrom = null,
        [FromQuery] int? yearTo = null,
        [FromQuery] decimal? priceFrom = null,
        [FromQuery] decimal? priceTo = null,
        CancellationToken ct = default)
    {
        var query = new GetCarsQuery(
            Paging: new PageRequest
            {
                Page = page,
                PageSize = pageSize
            },
            BranchId: branchId,
            ManufacturerId: manufacturerId,
            CarModelId: carModelId,
            YearFrom: yearFrom,
            YearTo: yearTo,
            PriceFrom: priceFrom,
            PriceTo: priceTo
        );

        var result = await _mediator.Send(query, ct);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CarDetailsDto>> GetCarById([FromRoute] int id, CancellationToken ct = default)
    {
        var dto = await _mediator.Send(new GetCarByIdQuery(id), ct);
        if (dto is null) return NotFound();
        return Ok(dto);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<int>> CreateCar([FromBody] CreateCarRequestDto request, CancellationToken ct = default)
    {
        try
        {
            var id = await _mediator.Send(new CreateCarCommand(request), ct);
            return CreatedAtAction(nameof(GetCarById), new { id }, id);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [AllowAnonymous]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCar([FromRoute] int id, [FromBody] UpdateCarRequestDto request, CancellationToken ct = default)
    {
        try
        {
            var ok = await _mediator.Send(new UpdateCarCommand(id, request), ct);
            if (!ok) return NotFound();
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [AllowAnonymous]
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> PatchCar(int id, [FromBody] PatchCarRequestDto request, CancellationToken ct = default)
    {
        try
        {
            var ok = await _mediator.Send(new PatchCarCommand(id, request), ct);
            if (!ok) return NotFound();
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [AllowAnonymous]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCar([FromRoute] int id, CancellationToken ct = default)
    {
        var ok = await _mediator.Send(new DeleteCarCommand(id), ct);
        if (!ok) return NotFound();
        return NoContent();
    }


}