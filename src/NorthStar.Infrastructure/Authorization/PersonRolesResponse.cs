using NorthStar.Domain.People;

namespace NorthStar.Infrastructure.Authorization;
public sealed class PersonRolesResponse
{
    public Guid Id { get; init; }

    public List<Role> Roles { get; init; } = [];
}
