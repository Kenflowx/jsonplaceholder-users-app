using System.Security.Claims;
using Backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Modules.Reservations;

[ApiController]
[Authorize]
[Route("api/reservations")]
public class ReservationsController(AppDbContext db) : ControllerBase
{
    private int CurrentUserId => int.Parse(User.FindFirstValue("sub")!);

    [HttpGet]
    public async Task<IActionResult> Mine()
    {
        var userId = CurrentUserId;
        var list = await db.Reservations
            .AsNoTracking()
            .Where(r => r.UserId == userId)
            .OrderByDescending(r => r.CreatedAt)
            .Select(r => new ReservationResponse(
                r.Id, r.DestinationId, r.Destination!.Name, r.Destination.Country,
                r.Travelers, r.TravelDate, r.Travelers * r.Destination.PricePerPerson, r.CreatedAt))
            .ToListAsync();
        return Ok(list);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateReservationRequest request)
    {
        if (request.Travelers is < 1 or > 20)
            return BadRequest(new { message = "El número de viajeros debe estar entre 1 y 20" });

        var minDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1));
        if (request.TravelDate < minDate)
            return BadRequest(new { message = "La fecha de viaje no puede estar en el pasado" });

        var destination = await db.Destinations.FindAsync(request.DestinationId);
        if (destination is null)
            return NotFound(new { message = "Destino no encontrado" });

        var reservation = new Reservation
        {
            UserId = CurrentUserId,
            DestinationId = destination.Id,
            Travelers = request.Travelers,
            TravelDate = request.TravelDate
        };

        db.Reservations.Add(reservation);
        await db.SaveChangesAsync();

        return StatusCode(StatusCodes.Status201Created, new ReservationResponse(
            reservation.Id, destination.Id, destination.Name, destination.Country,
            reservation.Travelers, reservation.TravelDate,
            reservation.Travelers * destination.PricePerPerson, reservation.CreatedAt));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Cancel(int id)
    {
        var userId = CurrentUserId;
        var reservation = await db.Reservations.FirstOrDefaultAsync(r => r.Id == id && r.UserId == userId);
        if (reservation is null) return NotFound(new { message = "Reserva no encontrada" });

        db.Reservations.Remove(reservation);
        await db.SaveChangesAsync();
        return NoContent();
    }
}