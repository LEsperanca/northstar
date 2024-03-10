using NorthStar.Domain.Abstractions;

namespace NorthStar.Domain.People.Events;
public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
