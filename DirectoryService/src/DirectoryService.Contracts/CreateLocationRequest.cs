namespace DirectoryService.Contracts;

public record CreateLocationRequest(Guid Id, string Name, string Address, string Timezone);