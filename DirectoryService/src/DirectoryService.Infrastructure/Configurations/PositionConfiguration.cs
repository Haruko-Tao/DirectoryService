using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("positions");

        builder.HasKey(p => p.Id).HasName("pk_postions");

        builder.Property(p => p.Id)
            .HasConversion(p => p.Value, p => new Position.PositionId(p))
            .HasColumnName("id");

        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnName("name")
            .HasConversion(p => p.Value, p => new Name(p));

        builder
            .Property(p => p.Description)
            .IsRequired()
            .HasColumnName("description")
            .HasMaxLength(500)
            .HasConversion(p => p.Value, p => new Description(p));

        builder
            .Property(p => p.IsActive)
            .HasColumnName("isactive");

        builder
            .Property(p => p.CreatedAt)
            .HasColumnName("createdat")
            .IsRequired();

        builder
            .Property(p => p.UpdatedAt)
            .IsRequired()
            .HasColumnName("updatedat");
    }
}