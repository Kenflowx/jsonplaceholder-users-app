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
}