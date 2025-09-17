namespace DirectoryService.Domain;

public class Location
{
    public Location(Name name, string address)
    {
        Name = name;
        Address = address;
    }

    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public string Address { get; private set; }

    public TimeZone Timezone { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }
}

public record TimeZone
{
    public string Value { get; }

    public TimeZone(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("IANA код не должен быть пустым");

        try
        {
            var tz = TimeZoneInfo.FindSystemTimeZoneById(value);
        }
        catch (TimeZoneNotFoundException)
        {
            throw new ArgumentException("Неверный IANA time zone id");
        }
        catch (InvalidTimeZoneException)
        {
            throw new ArgumentException("Неферный формат time zone");
        }

        Value = value;
    }
}

public record Name
{
    public string Value { get; }

    public const int MAX_LENGTH = 150;

    public Name(string value)
    {
        if (value.Length > MAX_LENGTH || string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("The name is too long for 150 characters or the name cannot be empty.");

        Value = value;
    }
}

