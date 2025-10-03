using CSharpFunctionalExtensions;
using Shared.Exceptions;

namespace DirectoryService.Domain.Location;

public record Name
{
    public string Value { get; }
    public const int MAX_LENGTH = 150;
    
    public Name(string value)
    {
        Value = value;
    }

    public static Result<Name, Errors> Create(string value)
    {
        var errors = new List<Error>();

        if (string.IsNullOrWhiteSpace(value))
            errors.Add(GeneralErrors.Validation("name", "Name cannot be empty"));

        if (value?.Length > MAX_LENGTH)
            errors.Add(GeneralErrors.Validation("name", $"Name cannot be longer than {MAX_LENGTH} characters"));

        if (errors.Any())
            return Result.Failure<Name, Errors>(new Errors(errors));

        return Result.Success<Name, Errors>(new Name(value));
    }


}