using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthStar.Api.Controllers.Projects;
using NorthStar.Application.Persons.Create;
using NorthStar.Application.Persons.GetLoggedInUser;
using NorthStar.Application.Persons.Login;
using NorthStar.Domain.Abstractions;
using NorthStar.Domain.People;

namespace NorthStar.Api.Controllers.People;

[Authorize]
[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly ISender _sender;

    public PeopleController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Create(PersonRequest personRequest, CancellationToken cancellationToken)
    {
        var command = new CreatePersonCommand(
            personRequest.Email, 
            personRequest.Name, 
            personRequest.Password);

        var result = await _sender.Send(command, cancellationToken);

        if(result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> LogIn(
    LoginPersonRequest request,
    CancellationToken cancellationToken)
    {
        var command = new LoginPersonComand(request.Email, request.Password);

        Result<AccessTokenResponse> result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("me")]
    [Authorize(Roles = Roles.Registered)]
    public async Task<IActionResult> GetLoggedInUser(CancellationToken cancellationToken)
    {
        var query = new GetLoggedInUserQuery();

        Result<PersonResponse> result = await _sender.Send(query, cancellationToken);

        return Ok(result.Value);
    }
}
