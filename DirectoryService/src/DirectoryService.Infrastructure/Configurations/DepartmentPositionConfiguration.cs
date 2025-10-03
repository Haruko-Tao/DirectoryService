using DirectoryService.Domain;
using DirectoryService.Domain.Associations;
using DirectoryService.Domain.Department;
using DirectoryService.Domain.Position;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class DepartmentPositionConfiguration : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    {
        builder.ToTable("department_positions");

        builder
            .HasKey(dp => new { dp.PositionId, dp.DepartmentId })
            .HasName("pk_department_position");

        builder
            .HasOne<Department>()
            .WithMany(dp => dp.DepartmentPositions)
            .HasForeignKey(dp => dp.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne<Position>()
            .WithMany()
            .HasForeignKey(dp => dp.PositionId)
            .HasPrincipalKey(p => p.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}