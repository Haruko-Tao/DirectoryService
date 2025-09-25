namespace DirectoryService.Application;

public record CreateLocationRequest(Guid id, string name, string address, string timezone);