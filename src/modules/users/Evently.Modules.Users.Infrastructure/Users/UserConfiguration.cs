using Evently.Modules.Users.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evently.Modules.Users.Infrastructure.Users;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName).HasMaxLength(256);

        builder.Property(u => u.LastName).HasMaxLength(256);

        builder.Property(u => u.Email).HasMaxLength(512);

        builder.HasIndex(u => u.Email).IsUnique();
    }
}