using NorthStar.Application.Abstractions.Messaging;

namespace NorthStar.Application.Projects.Read;

public record GetProjectQuery(Guid projectId) : IQuery<ProjectResponse>;
