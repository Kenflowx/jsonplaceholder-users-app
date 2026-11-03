using Backend.Modules.Destinations;

namespace Backend.Modules.Reservations;

public class Reservation
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int DestinationId { get; set; }
    public Destination? Destination { get; set; }
    public int Travelers { get; set; }
    public DateOnly TravelDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public record CreateReservationRequest(int DestinationId, int Travelers, DateOnly TravelDate);

public record ReservationResponse(
    int Id, int DestinationId, string DestinationName, string Country,
    int Travelers, DateOnly TravelDate, decimal Total, DateTime CreatedAt);