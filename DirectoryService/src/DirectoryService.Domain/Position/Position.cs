namespace DirectoryService;

public class Position
{
    public Position(Name name, Description description)
    {
        Name = name;
        Description = description;
    }
    
    public Guid Id { get; private set; }
    
    public Name Name { get; private set; }
    
    public Description? Description { get; private set; }
    
    public bool IsActive { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public DateTime UpdatedAt { get; private set; }
}