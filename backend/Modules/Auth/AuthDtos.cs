namespace Backend.Modules.Auth;
public record RegisterRequest(string Name, string Email, string Password);
public record LoginRequest(string Email, string Password);
public record UserResponse(int Id, string Name, string Email);