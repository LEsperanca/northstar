using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NorthStar.Infrastructure;

namespace Northstar.Application.IntegrationTests.Infrastructure;
public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
{
    private readonly IServiceScope _scope;
    protected readonly ISender _sender;
    protected readonly NorthStarEfCoreDbContext _dbContext;

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory) 
    {
        _scope = factory.Services.CreateScope();

        _sender = _scope.ServiceProvider.GetRequiredService<ISender>();

        _dbContext = _scope.ServiceProvider.GetRequiredService<NorthStarEfCoreDbContext>();
    }
}
