using DirectoryService.Domain.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Path = DirectoryService.Domain.Department.Path;

namespace DirectoryService.Infrastructure.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");

        builder.HasKey(d => d.Id).HasName("pk_departments");

        builder.Property(d => d.Id).HasColumnName("id");

        builder
            .Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(450)
            .HasColumnName("name")
            .HasConversion(d => d.Value, d => new Domain.Department.Name(d));

        builder
            .Property(d => d.Identifier)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("identifier")
            .HasConversion(d => d.Value, d => new Identifier(d));

        builder
            .Property(d => d.ParentId)
            .IsRequired(false)
            .HasColumnName("parent_id");

        builder
            .HasOne(d => d.Parent)
            .WithMany(d => d.Children)
            .HasForeignKey(d => d.ParentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(d => d.Path)
            .IsRequired()
            .HasColumnName("path")
            .HasConversion(d => d.Value, d => new Path(d));

        builder
            .Property(d => d.Depth)
            .IsRequired()
            .HasColumnName("depth");

        builder
            .Property(d => d.IsActive)
            .HasColumnName("isactive");

        builder
            .Property(d => d.CreatedAt)
            .IsRequired()
            .HasColumnName("createdat");

        builder
            .Property(d => d.UpdatedAt)
            .IsRequired()
            .HasColumnName("updatedat");
    }
}