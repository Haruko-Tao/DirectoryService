namespace DirectoryService.Domain.Associations;

public class DepartmentPosition
{
    public Guid DepartmentId { get; private set; }
    public Position.Position.PositionId PositionId { get; private set; }
}