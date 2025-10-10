namespace DirectoryService.Domain.Associations;

public class DepartmentLocation
{
    public Guid DepartmentId { get; private set; }
    public Location.Location.LocationId LocationId { get; private set; }
}