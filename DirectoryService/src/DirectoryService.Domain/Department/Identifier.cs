namespace DirectoryService.Domain.Department;

public record Identifier
{
    public const int MAX_LENGTH = 150;
    public string Value { get; }

    public Identifier(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > MAX_LENGTH)
            throw new ArgumentException("Identifier cannot be empty or more than 150 characters.");
        Value = value;
    }
}