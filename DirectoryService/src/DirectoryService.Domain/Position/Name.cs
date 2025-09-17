namespace DirectoryService;

public record Name
{
    public string Value { get; }

    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 150)
            throw new ArgumentException("The name cannot be empty or be more than 150 characters long.");
        Value = value;
    }
}