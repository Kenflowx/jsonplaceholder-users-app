using System.Security.Claims;
using Backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Modules.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController(AppDbContext db, TokenService tokens) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var name = request.Name.Trim();
        var email = request.Email.Trim().ToLowerInvariant();

        if (name.Length < 2)
            return BadRequest(new { message = "El nombre debe tener al menos 2 caracteres" });
        if (!email.Contains('@') || !email.Contains('.'))
            return BadRequest(new { message = "El correo no es válido" });
        if (request.Password.Length < 8)
            return BadRequest(new { message = "La contraseña debe tener al menos 8 caracteres" });

        if (await db.Users.AnyAsync(u => u.Email == email))
            return Conflict(new { message = "Ya existe una cuenta con ese correo" });

        var user = new AppUser
        {
            Name = name,
            Email = email,
            // La contraseña nunca se guarda en texto plano: solo su hash BCrypt
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        db.Users.Add(user);
        await db.SaveChangesAsync();

        return StatusCode(StatusCodes.Status201Created, new UserResponse(user.Id, user.Name, user.Email));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var email = request.Email.Trim().ToLowerInvariant();
        var user = await db.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return Unauthorized(new { message = "Credenciales inválidas" });

        var expires = DateTime.UtcNow.AddHours(2);
        var token = tokens.Create(user, expires);

        // El JWT va en una cookie HttpOnly: JavaScript no puede leerla
        Response.Cookies.Append(AuthDefaults.CookieName, token, new CookieOptions
        {
            HttpOnly = true,
            Secure = Request.IsHttps,
            SameSite = SameSiteMode.Lax,
            Expires = expires
        });

        return Ok(new UserResponse(user.Id, user.Name, user.Email));
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete(AuthDefaults.CookieName);
        return NoContent();
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        var id = int.Parse(User.FindFirstValue("sub")!);
        var user = await db.Users.FindAsync(id);
        if (user is null) return Unauthorized();
        return Ok(new UserResponse(user.Id, user.Name, user.Email));
    }
}