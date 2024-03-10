namespace NorthStar.Application.Projects.UpdateProject;

using NorthStar.Application.Abstractions.Messaging;

public record UpdateProjectCommand(Guid projectId, string name, string description) : ICommand<Guid>;
