using DirectoryService.Domain;
using DirectoryService.Domain.Department;
using Microsoft.EntityFrameworkCore;

namespace DirectoryService.Application.Database;

public interface IDirectoryServiceDbContext
{
    DbSet<Location> Locations { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}