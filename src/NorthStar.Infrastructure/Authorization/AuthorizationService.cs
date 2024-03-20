using Microsoft.EntityFrameworkCore;
using NorthStar.Application.Abstractions.Caching;
using NorthStar.Domain.Abstractions;
using NorthStar.Domain.People;
using System.Reflection.Metadata.Ecma335;

namespace NorthStar.Infrastructure.Authorization;
internal sealed class AuthorizationService
{
    private readonly NorthStarEfCoreDbContext _dbContext;
    private readonly ICacheService _cacheService;

    public AuthorizationService(NorthStarEfCoreDbContext dbContext, ICacheService cacheService)
    {
        _dbContext = dbContext;
        _cacheService = cacheService;
    }
    public async Task<PersonRolesResponse> GetRolesForUserAsync(string identityId)
    {
        var cacheKey = $"auth:roles-{identityId}";

        var roles = await _cacheService.GetAsync<PersonRolesResponse>(cacheKey);

        if(roles is not null)
        {
            return roles;
        }
        
        roles = await _dbContext.Set<Person>()
        .Where(person => person.IdentityId == identityId)
        .Select(person => new PersonRolesResponse
        {
            Id = person.Id,
            Roles = person.Roles.ToList()
        })
        .FirstAsync();

        await _cacheService.SetAsync(cacheKey, roles);
        
        return roles;
    }

    public async Task<HashSet<string>> GetPermissionForPersonAsync(string identityId)
    {
        var cacheKey = $"auth:permissions-{identityId}";

        var cachedPermissions = await _cacheService.GetAsync<HashSet<string>>(cacheKey);

        if(cachedPermissions is not null)
        {
            return cachedPermissions;
        }

        var permissions = await _dbContext.Set<Person>()
           .Where(person => person.IdentityId == identityId)
           .SelectMany(person => person.Roles.Select(role => role.Permissions))
           .FirstAsync();

        var permissionSet = permissions.Select(permission => permission.Name).ToHashSet();

        await _cacheService.SetAsync<HashSet<string>>(cacheKey, permissionSet);


        return permissionSet;
    }
}

