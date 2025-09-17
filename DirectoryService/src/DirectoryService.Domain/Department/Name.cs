namespace DirectoryService.Domain.Department;

public record Name
{
    public string Value { get; }

    public const int MAX_LENGTH = 150;

    public Name(string value)
    {
        if (value.Length > MAX_LENGTH || string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("The name is too long for 150 characters or the name cannot be empty.");

        Value = value;
    }
}