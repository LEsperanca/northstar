namespace NorthStar.Infrastructure;

using Asp.Versioning;
using Bookify.Application.Abstractions.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthStar.Application.Abstractions.Clock;
using NorthStar.Application.Abstractions.Email;
using NorthStar.Domain.Abstractions;
using NorthStar.Domain.People.Repository;
using NorthStar.Domain.Projects.Repository;
using NorthStar.Domain.WorkItems.Repository;
using NorthStar.Infrastructure.Clock;
using NorthStar.Infrastructure.Data;
using NorthStar.Infrastructure.Email;
using NorthStar.Infrastructure.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();

        var connectionString = configuration.GetConnectionString("Database") ?? 
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<NorthStarEfCoreDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IPeopleRepository, PeopleRepository>();
        services.AddScoped<IWorkItemRepository, WorkItemRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<NorthStarEfCoreDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        AddApiVersioning(services);

        return services;
    }

    private static void AddApiVersioning(IServiceCollection services)
    {
        services.AddApiVersioning(options => 
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        })
        .AddMvc()
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });
    }
}
