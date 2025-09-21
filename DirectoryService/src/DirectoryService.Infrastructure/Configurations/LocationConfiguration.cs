using DirectoryService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeZone = DirectoryService.Domain.TimeZone;

namespace DirectoryService.Infrastructure.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locations");
        
        builder.HasKey(l => l.Id).HasName("pk_locations");

        builder.Property(l => l.Id)
            .HasConversion(l => l.Value, l => new Location.LocationId(l))
            .HasColumnName("id");

        builder.Property(l => l.Name)
            .HasConversion(l => l.Value, l => new Domain.Name(l))
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(l => l.Address)
            .HasConversion(l => l.Value, l => new Address(l))
            .HasColumnName("address")
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(l => l.Timezone)
            .HasConversion(l => l.Value, l => new TimeZone(l))
            .HasColumnName("timezone")
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(l => l.IsActive)
            .HasColumnName("isactive");

        builder.Property(l => l.CreatedAt)
            .HasColumnName("createdat")
            .IsRequired();

        builder.Property(l => l.UpdatedAt)
            .HasColumnName("updatedat")
            .IsRequired();
    } 
}