namespace DirectoryService.Domain;

public class DepartmentLocation
{
    public Guid DepartmentId { get; private set; }
    public Location.LocationId LocationId { get; private set; }
}