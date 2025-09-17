namespace DirectoryService;

public record Description
{
    public string Value { get; }

    public Description(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("The description cannot be empty.");
        Value = value;
    }
}