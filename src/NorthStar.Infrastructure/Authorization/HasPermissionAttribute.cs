using Microsoft.AspNetCore.Authorization;

namespace NorthStar.Infrastructure.Authorization;
public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string permission) 
        : base(permission)
    {
        
    }
}
