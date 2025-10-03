using CSharpFunctionalExtensions;
using Shared.Exceptions;

namespace DirectoryService.Domain.Location;

public record Address
{
    public static int MAX_LENGTH = 150;
    public string Value { get; }
    
    public Address(string value)
    {
        Value = value;
    }

    public static Result<Address, Errors> Create(string value)
    {
        var errors = new List<Error>();

        if (string.IsNullOrWhiteSpace(value))
            errors.Add(GeneralErrors.Validation("address", "The address cannot be empty"));

        if (value?.Length > MAX_LENGTH)
            errors.Add(GeneralErrors.Validation("address", $"Address cannot be longer than {MAX_LENGTH} characters"));

        if (errors.Any())
            return Result.Failure<Address, Errors>(new Errors(errors));

        return Result.Success<Address, Errors>(new Address(value));
    }

}