namespace DirectoryService.Domain.Position;

public class Position
{
    public record PositionId(Guid Value);
    public Position(PositionId id, Name name, Description description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    
    public PositionId Id { get; private set; }
    
    public Name Name { get; private set; }
    
    public Description Description { get; private set; }
    
    public bool IsActive { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public DateTime UpdatedAt { get; private set; }
}