using DirectoryService.Application.Database;
using DirectoryService.Domain;
using TimeZone = DirectoryService.Domain.TimeZone;

namespace DirectoryService.Application;

public class CreateLocationHandle
{
    private readonly IDirectoryServiceDbContext _dbContext;

    public CreateLocationHandle(IDirectoryServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Guid> Handle(CreateLocationRequest request, CancellationToken cancellationToken)
    {
        var location = Location.Create(request.name, request.address, request.timezone);

        await _dbContext.Locations.AddAsync(location.Value, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return location.Value.Id.Value;
    }
}