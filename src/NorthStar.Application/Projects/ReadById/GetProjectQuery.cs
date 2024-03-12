using NorthStar.Application.Abstractions.Messaging;

namespace NorthStar.Application.Projects.ReadById;

public record GetProjectQuery(Guid projectId) : IQuery<ProjectResponse>;
