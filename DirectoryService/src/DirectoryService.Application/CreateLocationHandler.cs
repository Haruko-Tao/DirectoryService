using CSharpFunctionalExtensions;
using DirectoryService.Application.Database;
using DirectoryService.Domain;
using TimeZone = DirectoryService.Domain.TimeZone;

namespace DirectoryService.Application;

public class CreateLocationHandler
{
    private readonly IDirectoryServiceRepository _locationRepository;

    public CreateLocationHandler(IDirectoryServiceRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }
    public async Task<Result<Guid>> Handle(CreateLocationRequest request, CancellationToken cancellationToken)
    {
        var nameResult = Domain.Name.Create(request.Name);
        if (nameResult.IsFailure)
            return Result.Failure<Guid>(nameResult.Error);

        var addressResult = Address.Create(request.Address);
        if (addressResult.IsFailure)
            return Result.Failure<Guid>(addressResult.Error);

        var timezoneResult = TimeZone.Create(request.Timezone);
        if (timezoneResult.IsFailure)
            return Result.Failure<Guid>(timezoneResult.Error);

        var locationResult = Location.Create(nameResult.Value, addressResult.Value, timezoneResult.Value);
        if (locationResult.IsFailure)
            return Result.Failure<Guid>(locationResult.Error);

        await _locationRepository.Add(locationResult.Value, cancellationToken);

        return Result.Success(locationResult.Value.Id.Value);
    }
}