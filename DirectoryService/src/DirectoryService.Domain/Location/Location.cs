using CSharpFunctionalExtensions;

namespace DirectoryService.Domain;

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

    public static Result<Location> Create(string name, string address, string timezone)
    {
        try
        {
            var nameVo = new Name(name);
            var addressVo = new Address(address);
            var tzVo = new TimeZone(timezone);

            var id = new LocationId(Guid.NewGuid());
            
            return Result.Success(new Location(id, nameVo, addressVo, tzVo));
        }
        catch (ArgumentException ex)
        {
            return Result.Failure<Location>(ex.Message);
        }
    }
}

