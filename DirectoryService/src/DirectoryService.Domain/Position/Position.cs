namespace DirectoryService.Domain;

public class Position
{
    public Position(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public Guid Id { get; private set; }
    
    public string Name { get; private set; }
    
    public string? Description { get; private set; }
    
    public bool IsActive { get; private set; }
    
    public DateTime CreatedAt { get; private set; } 
    
    public DateTime UpdatedAt { get; private set; }
}