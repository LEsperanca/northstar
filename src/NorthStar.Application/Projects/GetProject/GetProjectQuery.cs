namespace NorthStar.Application.Projects.GetProject;

using NorthStar.Application.Abstractions.Messaging;

public record GetProjectQuery(Guid projectId) : IQuery<ProjectResponse>;
