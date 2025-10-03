using CSharpFunctionalExtensions;
using Shared.Exceptions;

namespace DirectoryService.Domain.Department;

public record Identifier
{
    public string Value { get; }

    public Identifier(string value)
    {
        Value = value;
    }

    public static Result<Identifier, Errors> Create(string value)
    {
        var errors = new List<Error>();

        if (string.IsNullOrWhiteSpace(value))
            errors.Add(GeneralErrors.Validation("identifier", "Identifier cannot be empty"));

        if (errors.Any())
            return Result.Failure<Identifier, Errors>(new Errors(errors));

        return Result.Success<Identifier, Errors>(new Identifier(value));
    }
}
