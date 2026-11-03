namespace Backend.Modules.Destinations;

public class Destination
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Country { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal PricePerPerson { get; set; }
    public int DurationDays { get; set; }
}

public record CreateDestinationRequest(
    string Name, string Country, string Description, decimal PricePerPerson, int DurationDays);