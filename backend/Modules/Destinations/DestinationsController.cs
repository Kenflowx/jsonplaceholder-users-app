using Backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Modules.Destinations;

[ApiController]
[Authorize]
[Route("api/destinations")]
public class DestinationsController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await db.Destinations.AsNoTracking().OrderBy(d => d.Name).ToListAsync();
        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var destination = await db.Destinations.FindAsync(id);
        return destination is null
            ? NotFound(new { message = "Destino no encontrado" })
            : Ok(destination);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDestinationRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Country))
            return BadRequest(new { message = "Nombre y país son obligatorios" });
        if (request.PricePerPerson <= 0 || request.DurationDays <= 0)
            return BadRequest(new { message = "Precio y duración deben ser mayores a 0" });

        var destination = new Destination
        {
            Name = request.Name.Trim(),
            Country = request.Country.Trim(),
            Description = request.Description.Trim(),
            PricePerPerson = request.PricePerPerson,
            DurationDays = request.DurationDays
        };

        db.Destinations.Add(destination);
        await db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = destination.Id }, destination);
    }
}