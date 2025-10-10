using CSharpFunctionalExtensions;
using DirectoryService.Application.Database;
using DirectoryService.Domain;
using DirectoryService.Domain.Location;
using Shared.Exceptions;

namespace DirectoryService.Infrastructure.Repositories;

public class EfCoreLocationRepository : IDirectoryServiceRepository
{
    private readonly DirectoryServiceDbContext _dbContext;

    public EfCoreLocationRepository(DirectoryServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<Guid, Errors>> Add(Location location, CancellationToken cancellationToken = default)
    {
        try
        {
            await _dbContext.Locations.AddAsync(location, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success<Guid, Errors>(location.Id.Value);
        }
        catch (Exception ex)
        {
            return Result.Failure<Guid, Errors>(
                GeneralErrors.Failure("database.save.error", $"Failure to save location: {ex.Message}"));
        }
    }
}