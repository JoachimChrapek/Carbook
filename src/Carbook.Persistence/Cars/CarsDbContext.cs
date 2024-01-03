using Carbook.Domain.Cars;
using Microsoft.EntityFrameworkCore;

namespace Carbook.Persistence.Cars;

public class CarsDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; } = null!;

    public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarsDbContext).Assembly);
    }
}