using CSharpFunctionalExtensions;

namespace DirectoryService.Domain;

public record TimeZone
{
    public string Value { get; }
  
    public TimeZone(string value)
    {
        Value = value;
    }

    public static Result<TimeZone> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<TimeZone>("The IANA come must not be empty");

        try
        {
            var _ = System.TimeZoneInfo.FindSystemTimeZoneById(value);
        }
        catch (TimeZoneNotFoundException)
        {
            return Result.Failure<TimeZone>("Invalid IANA time zone id");
        }
        catch (InvalidTimeZoneException)
        {
            return Result.Failure<TimeZone>("Invalid time zone format");
        }

        return Result.Success(new TimeZone(value));
    }
    
}