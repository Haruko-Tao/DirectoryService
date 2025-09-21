namespace DirectoryService.Domain;

public class DepartmentPosition
{
    public Guid DepartmentId { get; private set; }
    public Position.PositionId PositionId { get; private set; }
}