using NorthStar.Application.Abstractions.Messaging;

namespace NorthStar.Application.Projects.Create;
public record CreateProjectCommand(string name, string description) : ICommand<Guid>;
