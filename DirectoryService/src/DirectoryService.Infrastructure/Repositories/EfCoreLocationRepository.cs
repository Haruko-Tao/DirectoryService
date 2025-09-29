using DirectoryService.Application.Database;
using DirectoryService.Domain;

namespace DirectoryService.Infrastructure.Repositories;

public class EfCoreLocationRepository : IDirectoryServiceRepository
{
    private readonly DirectoryServiceDbContext _dbContext;

    public EfCoreLocationRepository(DirectoryServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Add(Location location, CancellationToken cancellationToken = default)
    {
        await _dbContext.Locations.AddAsync(location, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return location.Id.Value;
    }
}