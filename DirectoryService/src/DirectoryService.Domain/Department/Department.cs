namespace DirectoryService.Domain.Department;

public class Department
{
    public Department(Name name, string identifier, short depth, Path path)
    {
        Id = Guid.NewGuid();
        Name = name;
        Identifier = identifier;
        Depth = depth;
        Path = path;
    }

    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public string Identifier { get; private set; }

    public Guid? ParentId { get; private set; }

    public Path Path { get; private set; }

    public short Depth { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }
}

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