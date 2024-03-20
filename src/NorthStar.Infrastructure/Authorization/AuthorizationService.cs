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

    public async Task<HashSet<string>> GetPermissionForPersonAsync(string identityId)
    {
        var permissions = await _dbContext.Set<Person>()
           .Where(person => person.IdentityId == identityId)
           .SelectMany(person => person.Roles.Select(role => role.Permissions))
           .FirstAsync();


        var permissionSet = permissions.Select(permission => permission.Name).ToHashSet();

        return permissionSet;
    }
}

