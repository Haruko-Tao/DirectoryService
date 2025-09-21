using DirectoryService.Domain;
using DirectoryService.Domain.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class DepartmentLocationConfiguration : IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        builder.ToTable("department_locations");

        builder
            .HasKey(dl => new { dl.DepartmentId, dl.LocationId })
            .HasName("pk_department_location");

        builder
            .HasOne<Department>()
            .WithMany(dl => dl.DepartmentLocations)
            .HasForeignKey(dl => dl.DepartmentId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne<Location>()
            .WithMany()
            .HasForeignKey(dl => dl.LocationId)
            .HasPrincipalKey(l => l.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }    
}