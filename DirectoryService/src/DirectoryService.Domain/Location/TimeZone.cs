namespace DirectoryService.Domain;

public record TimeZone
{
    public string Value { get; }

    public TimeZone(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("The IANA code must not be empty");

        try
        {
            var tz = TimeZoneInfo.FindSystemTimeZoneById(value);
        }
        catch (TimeZoneNotFoundException)
        {
            throw new ArgumentException("Invalid IANA time zone id");
        }
        catch (InvalidTimeZoneException)
        {
            throw new ArgumentException("Invalid time zone format");
        }

        Value = value;
    }
}