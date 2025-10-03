using CSharpFunctionalExtensions;
using Shared.Exceptions;

namespace DirectoryService.Domain.Location;

public record TimeZone
{
    public string Value { get; }
  
    public TimeZone(string value)
    {
        Value = value;
    }

    public static Result<TimeZone, Errors> Create(string value)
    {
        var errors = new List<Error>();

        if (string.IsNullOrWhiteSpace(value))
        {
            errors.Add(GeneralErrors.Validation("timezone", "The IANA code must not be empty"));
            return Result.Failure<TimeZone, Errors>(new Errors(errors));
        }

        try
        {
            var _ = TimeZoneInfo.FindSystemTimeZoneById(value);
        }
        catch (TimeZoneNotFoundException)
        {
            errors.Add(GeneralErrors.Validation("timezone", "Invalid IANA time zone id"));
        }
        catch (InvalidTimeZoneException)
        {
            errors.Add(GeneralErrors.Validation("timezone", "Invalid time zone format"));
        }

        if (errors.Any())
            return Result.Failure<TimeZone, Errors>(new Errors(errors));

        return Result.Success<TimeZone, Errors>(new TimeZone(value));
    }

    
}