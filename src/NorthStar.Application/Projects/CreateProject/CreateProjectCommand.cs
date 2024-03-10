using NorthStar.Application.Abstractions.Messaging;

namespace NorthStar.Application.Projects.CreateProject;
public record CreateProjectCommand(string name, string description) : ICommand<Guid>;
