using CSharpFunctionalExtensions;

namespace DirectoryService.Domain;

public record Address
{
    public string Value { get; }
    
    public Address(string value)
    {
        Value = value;
    }

    public static Result<Address> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<Address>("The address cannot be empty");
        
        return Result.Success(new Address(value));
    }
}