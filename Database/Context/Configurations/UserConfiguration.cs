using Database.Context.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasIndex(x => x.Email);

        builder
            .HasIndex(x => x.PhoneNumber);

        builder
            .HasIndex(x => x.Username)
            .IsUnique();
    }
}