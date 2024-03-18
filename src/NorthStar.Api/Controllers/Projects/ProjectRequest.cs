namespace NorthStar.Api.Controllers.Projects;

public sealed record ProjectRequest(Guid Id, string Name, string Description);