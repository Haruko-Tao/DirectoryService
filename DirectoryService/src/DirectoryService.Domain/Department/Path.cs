using CSharpFunctionalExtensions;
using Shared.Exceptions;

namespace DirectoryService.Domain.Department;

public record Path
{
    public string Value { get; }

    public Path(string value)
    {
        Value = value;
    }

    public static Result<Path, Errors> Create(string value)
    {
        var errors = new List<Error>();

        if (string.IsNullOrWhiteSpace(value))
            errors.Add(GeneralErrors.Validation("path", "The path cannot be empty"));

        if (value?.Contains("..") == true)
            errors.Add(GeneralErrors.Validation("path", "The path must not contain two points in a row"));

        if (value?.StartsWith('.') == true || value?.EndsWith('.') == true)
            errors.Add(GeneralErrors.Validation("path", "The path must not start or end with a dot"));

        if (!string.IsNullOrWhiteSpace(value))
        {
            foreach (var c in value)
            {
                if (!(char.IsLetterOrDigit(c) || c == '-' || c == '.'))
                {
                    errors.Add(GeneralErrors.Validation("path", "The path contains invalid characters"));
                    break;
                }
            }
        }

        if (errors.Any())
            return Result.Failure<Path, Errors>(new Errors(errors));

        return Result.Success<Path, Errors>(new Path(value));
    }
}
