using Microsoft.EntityFrameworkCore;
using NorthStar.Api.Middleware;
using NorthStar.Infrastructure;

namespace NorthStar.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        using var dbContext = scope.ServiceProvider.GetRequiredService<NorthStarEfCoreDbContext>();

        dbContext.Database.Migrate();
    }

    public static void UseCustomExceptionHandler(this IApplicationBuilder app) 
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
