namespace NorthStar.Domain.WorkItems.Events;

using NorthStar.Domain.Abstractions;

public sealed record WorkItemCreatedDomainEvent(Guid projectId) : IDomainEvent;

