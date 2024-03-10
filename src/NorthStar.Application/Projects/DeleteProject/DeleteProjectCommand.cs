using NorthStar.Application.Abstractions.Messaging;

namespace NorthStar.Application.Projects.DeleteProject;
public record DeleteProjectCommand(Guid projectId) : ICommand;
