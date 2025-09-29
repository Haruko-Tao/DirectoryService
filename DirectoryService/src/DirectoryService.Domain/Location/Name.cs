using CSharpFunctionalExtensions;

namespace DirectoryService.Domain;

public record Name
{
    public string Value { get; }
    public const int MAX_LENGTH = 150;
    
    public Name(string value)
    {
        Value = value;
    }

    public static Result<Name> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<Name>("The name cannot be empty.");

        if (value.Length > MAX_LENGTH)
            return Result.Failure<Name>($"The name is too long, maximum length is {MAX_LENGTH} characters");

        return Result.Success(new Name(value));
    }
}