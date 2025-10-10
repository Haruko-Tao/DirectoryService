using CSharpFunctionalExtensions;
using Shared.Exceptions;

namespace DirectoryService.Domain.Position;

public record Name
{
    public string Value { get; }

    public Name(string value)
    {
        Value = value;
    }

    public static Result<Name, Errors> Create(string value)
    {
        var errors = new List<Error>();

        if (string.IsNullOrWhiteSpace(value))
            errors.Add(GeneralErrors.Validation("name", "Name cannot be empty"));
        
        if (errors.Any())
            return Result.Failure<Name, Errors>(new Errors(errors));

        return Result.Success<Name, Errors>(new Name(value));
    }
}
