using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthStar.Application.Projects.Create;
using NorthStar.Application.Projects.Delete;
using NorthStar.Application.Projects.Read;
using NorthStar.Application.Projects.Update;

namespace NorthStar.Api.Controllers.Projects;
[ApiController]

[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly ISender _sender;

    public ProjectController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProjectRequest projectRequest, CancellationToken cancellationToken)
    {
        var command = new CreateProjectCommand(
            projectRequest.Name, 
            projectRequest.Description);

        var result = await _sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(Get), new { id = result.Value }, result.Value);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetProjectQuery(id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateProjectRequest projectRequest, CancellationToken cancellationToken)
    {
        var command = new UpdateProjectCommand(id, projectRequest.Name, projectRequest.Description);

        var result = await _sender.Send(command, cancellationToken);

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteProjectCommand(id);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? NoContent() : NotFound();
    }
}
