using Microsoft.EntityFrameworkCore;
using NorthStar.Domain.People;

namespace NorthStar.Infrastructure.Authorization;
internal sealed class AuthorizationService
{
    private readonly NorthStarEfCoreDbContext _dbContext;

    public AuthorizationService(NorthStarEfCoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<PersonRolesResponse> GetRolesForUserAsync(string identityId)
    {
        var roles = await _dbContext.Set<Person>()
            .Where(person => person.IdentityId == identityId)
            .Select(person => new PersonRolesResponse
            {
                Id = person.Id,
                Roles = person.Roles.ToList()
            })
            .FirstAsync();

        return roles;
    }
}

