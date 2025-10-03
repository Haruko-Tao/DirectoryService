using DirectoryService.Domain.Associations;

namespace DirectoryService.Domain.Department;

public class Department
{
    private List<Department> _children = [];

    private List<DepartmentLocation> _departmentLocations = [];

    private List<DepartmentPosition> _departmentPositions = [];
   
    public Department(
        Name name,
        Identifier identifier,
        short depth,
        Path path,
        Guid? parentId = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Identifier = identifier;
        Depth = depth;
        Path = path;
        ParentId = parentId;
    }

    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public Identifier Identifier { get; private set; }
    
    public Guid? ParentId { get; private set; }
    
    public Department? Parent { get; private set; }

    public IReadOnlyList<Department> Children => _children;

    public IReadOnlyList<DepartmentLocation> DepartmentLocations => _departmentLocations;

    public IReadOnlyList<DepartmentPosition> DepartmentPositions => _departmentPositions;

    public Path Path { get; private set; }

    public short Depth { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }
}