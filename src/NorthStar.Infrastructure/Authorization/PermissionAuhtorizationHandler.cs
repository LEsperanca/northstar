using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using NorthStar.Domain.People;
using NorthStar.Infrastructure.Authentication;

namespace NorthStar.Infrastructure.Authorization;
public sealed class PermissionAuhtorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IServiceProvider _serviceProvider;

    public PermissionAuhtorizationHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if(context.User.Identity is not { IsAuthenticated: true })
        {
            return;
        }

        using var scope = _serviceProvider.CreateScope();

        var authorizationService = scope.ServiceProvider.GetRequiredService<AuthorizationService>();

        var identityId = context.User.GetIdentityId();

        HashSet<string> permissions = await authorizationService.GetPermissionForPersonAsync(identityId);

        if(permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }
    }
}
