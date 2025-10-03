using CSharpFunctionalExtensions;
using Shared.Exceptions;

namespace DirectoryService.Domain.Location;

public class Location
{
    public record LocationId(Guid Value);
    public Location(LocationId id, Name name, Address address, TimeZone timezone)
    {
        Id = id;
        Name = name;
        Address = address;
        Timezone = timezone;
    }

    public LocationId Id { get; private set; }

    public Name Name { get; private set; }

    public Address Address { get; private set; }

    public TimeZone Timezone { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public static Result<Location, Errors> Create(Name name, Address address, TimeZone timezone)
    {
        var id = new LocationId(Guid.NewGuid());
        var location = new Location(id, name, address, timezone);

        return Result.Success<Location, Errors>(location);
    }
}

