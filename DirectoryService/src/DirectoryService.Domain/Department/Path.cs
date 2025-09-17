namespace DirectoryService.Domain.Department;

public record Path
{
    public string Value { get; }

    public Path(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("The path cannot be empty");

        if (value.Contains(".."))
            throw new ArgumentException("The path must not contain two points in a row.");

        if (value.StartsWith('.') || value.EndsWith('.'))
            throw new ArgumentException("The path must not start or end with a dot.");

        foreach (var c in value)
        {
            if (!(char.IsLetterOrDigit(c) || c == '-' || c == '.'))
                throw new ArgumentException("The path contains invalid characters");
        }

        Value = value;
    }
}