using Backend.Modules.Auth;
using Backend.Modules.Destinations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (!await db.Users.AnyAsync())
        {
            db.Users.Add(new AppUser
            {
                Name = "Kenovit Garcia",
                Email = "kenovit@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123*")
            });
        }

        if (!await db.Destinations.AnyAsync())
        {
            db.Destinations.AddRange(
                new Destination { Name = "Punta Cana", Country = "República Dominicana", Description = "Playas de arena blanca y resorts todo incluido en el Caribe.", PricePerPerson = 450m, DurationDays = 5 },
                new Destination { Name = "Samaná", Country = "República Dominicana", Description = "Avistamiento de ballenas, cascadas y playas tranquilas.", PricePerPerson = 380m, DurationDays = 4 },
                new Destination { Name = "Cancún", Country = "México", Description = "Mar turquesa, ruinas mayas y vida nocturna.", PricePerPerson = 720m, DurationDays = 6 },
                new Destination { Name = "París", Country = "Francia", Description = "Torre Eiffel, museos y gastronomía en la ciudad de la luz.", PricePerPerson = 1650m, DurationDays = 7 },
                new Destination { Name = "Madrid", Country = "España", Description = "Arte, tapas y vida cultural en el corazón de España.", PricePerPerson = 1400m, DurationDays = 7 },
                new Destination { Name = "Nueva York", Country = "Estados Unidos", Description = "Times Square, Central Park y Broadway.", PricePerPerson = 1200m, DurationDays = 5 }
            );
        }

        await db.SaveChangesAsync();
    }
}