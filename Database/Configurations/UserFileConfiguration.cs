using Database.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations;

public class UserFileConfiguration : IEntityTypeConfiguration<UserFile>
{
    public void Configure(EntityTypeBuilder<UserFile> builder)
    {
        builder
            .HasIndex(x => new { x.Keyword, x.Id })
            .IsUnique();
    }
}