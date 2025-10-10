using CSharpFunctionalExtensions;
using DirectoryService.Domain;
using DirectoryService.Domain.Location;
using Shared.Exceptions;

namespace DirectoryService.Application.Database;

public interface IDirectoryServiceRepository
{
    Task<Result<Guid, Errors>> Add(Location location, CancellationToken cancellationToken = default);
}