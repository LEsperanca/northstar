namespace NorthStar.Domain.Projects.Events;

using NorthStar.Domain.Abstractions;

public sealed record ProjectCreatedDomainEvent(Guid projectId) : IDomainEvent;