namespace DirectoryService.Domain;

public record Address
{
    public string Value { get; }

    public Address(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("The address cannot be empty.");
        Value = value;
    }
}