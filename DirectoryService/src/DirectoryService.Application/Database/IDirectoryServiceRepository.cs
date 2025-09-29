using DirectoryService.Domain;

namespace DirectoryService.Application.Database;

public interface IDirectoryServiceRepository
{
    Task<Guid> Add(Location location, CancellationToken cancellationToken = default);
}