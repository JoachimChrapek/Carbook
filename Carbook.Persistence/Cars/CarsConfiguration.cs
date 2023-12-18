using Carbook.Domain.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carbook.Persistence.Cars;

public class CarsConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedNever();

        builder.Property(c => c.Type)
            .HasConversion(
                carType => carType.ToString(),
                value => Enum.Parse<CarType>(value));
        
        //TODO change
        builder.Property(c => c.Make)
            .HasMaxLength(50);
        
        builder.Property(c => c.Model)
            .HasMaxLength(50);
    }
}