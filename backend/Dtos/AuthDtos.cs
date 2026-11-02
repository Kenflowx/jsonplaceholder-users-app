namespace Backend.Dtos;

public record LoginRequest(string Email, string Password);
public record UserResponse(int Id, string Name, string Email);