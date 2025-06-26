using Microsoft.EntityFrameworkCore;
using Parking.Core.Entities;

namespace Parking.Infrastructure.Database.Postgres;

internal sealed class AppDbContext : DbContext
{
    public DbSet<ParkingArea> ParkingAreas { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}