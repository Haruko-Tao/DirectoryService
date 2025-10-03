using CSharpFunctionalExtensions;
using DirectoryService.Application.Database;
using DirectoryService.Contracts;
using DirectoryService.Domain;
using DirectoryService.Domain.Location;
using Shared.Exceptions;
using TimeZone = DirectoryService.Domain.Location.TimeZone;

namespace DirectoryService.Application;

public class CreateLocationHandler
{
    private readonly IDirectoryServiceRepository _locationRepository;

    public CreateLocationHandler(IDirectoryServiceRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }
    public async Task<Result<Guid, Errors>> Handle(CreateLocationRequest request, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();

        var nameResult = Name.Create(request.Name);
        if (nameResult.IsFailure)
            errors.AddRange(nameResult.Error);

        var addressResult = Address.Create(request.Address);
        if (addressResult.IsFailure)
            errors.AddRange(addressResult.Error);

        var timezoneResult = TimeZone.Create(request.Timezone);
        if (timezoneResult.IsFailure)
            errors.AddRange(timezoneResult.Error);

        if (errors.Any())
            return Result.Failure<Guid, Errors>(new Errors(errors));

        var locationResult = Location.Create(nameResult.Value, addressResult.Value, timezoneResult.Value);
        if (locationResult.IsFailure)
            return Result.Failure<Guid, Errors>(locationResult.Error);

        await _locationRepository.Add(locationResult.Value, cancellationToken);

        return Result.Success<Guid, Errors>(locationResult.Value.Id.Value);
    }

}