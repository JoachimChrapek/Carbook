using Carbook.Shared.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carbook.API.Database;

public class CarsConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(c => c.Id);
        
        //TODO change
        builder.Property(c => c.Make)
            .HasMaxLength(50);
        
        builder.Property(c => c.Model)
            .HasMaxLength(50);
    }
}