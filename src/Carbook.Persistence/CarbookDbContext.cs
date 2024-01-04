using Carbook.Domain.Cars;
using Carbook.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Carbook.Persistence;

public class CarbookDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public CarbookDbContext(DbContextOptions<CarbookDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarbookDbContext).Assembly);
    }
}