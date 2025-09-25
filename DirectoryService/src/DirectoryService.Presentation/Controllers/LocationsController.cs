using DirectoryService.Application;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[ApiController]
[Route("/api/locations")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public async Task<Guid> Create([FromServices] CreateLocationHandle handle,
        [FromBody] CreateLocationRequest request,
        CancellationToken cancellationToken)
    {
         return await handle.Handle(request, cancellationToken);
    }
}