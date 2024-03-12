using NorthStar.Application.Abstractions.Messaging;

namespace NorthStar.Application.Projects.Delete;
public record DeleteProjectCommand(Guid projectId) : ICommand;
