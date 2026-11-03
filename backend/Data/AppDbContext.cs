using Backend.Modules.Auth;
using Backend.Modules.Destinations;
using Backend.Modules.Reservations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<Destination> Destinations => Set<Destination>();
    public DbSet<Reservation> Reservations => Set<Reservation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<Destination>().Property(d => d.PricePerPerson).HasPrecision(10, 2);
        modelBuilder.Entity<Reservation>()
            .HasOne<AppUser>().WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Destination).WithMany()
            .HasForeignKey(r => r.DestinationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}