using Carbook.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carbook.Persistence.Users;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .ValueGeneratedNever();

        builder.Property(u => u.Username);
        builder.Property(User.NameOfPasswordProperty)
            .HasColumnName("Password Hash");
    }
}