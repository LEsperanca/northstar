﻿using Bookify.Application.Abstractions.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NorthStar.Infrastructure;
using Testcontainers.Keycloak;
using Testcontainers.PostgreSql;
using Testcontainers.Redis;
using NorthStar.Infrastructure.Data;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using NorthStar.Infrastructure.Authentication;
using System.Net.Http.Json;
using Northstar.Api.FunctionalTests.People;
using Quartz;
using Quartz.Impl;
using System.Collections.Specialized;

namespace Northstar.FunctionalTests.Infrastructure;
public class FunctionalTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgresSqlContainer = new PostgreSqlBuilder()
        .WithImage("postgres:latest")
        .WithDatabase("northstar")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .Build();

    private readonly RedisContainer _redisContainer = new RedisBuilder()
        .WithImage("redis:latest")
        .Build();

    private readonly KeycloakContainer _keycloakContainer = new KeycloakBuilder()
        .WithResourceMapping(
        new FileInfo(".files/northstar-realm-export.json"),
        new FileInfo("/opt/keycloak/data/import/realm.json"))
        .WithCommand("--import-realm")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {

        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(ISchedulerFactory));
            Random nxt = new Random();
            
            var props = new NameValueCollection()
            {
                ["quartz.scheduler.instanceName"] = $"QuartzSchedulerFunctional-{nxt.Next()}"
            };

            var stdSchedulerFactory = new StdSchedulerFactory(props);
            services.TryAddSingleton<ISchedulerFactory>(stdSchedulerFactory);

            

            services.RemoveAll(typeof(DbContextOptions<NorthStarEfCoreDbContext>));

            string connectionString = $"{_postgresSqlContainer.GetConnectionString()};Pooling=False";

            services.AddDbContext<NorthStarEfCoreDbContext>(options =>
                options
                    .UseNpgsql(_postgresSqlContainer.GetConnectionString())
                    .UseSnakeCaseNamingConvention());

            services.RemoveAll(typeof(ISqlConnectionFactory));

            services.AddSingleton<ISqlConnectionFactory>(_ =>
                new SqlConnectionFactory(_postgresSqlContainer.GetConnectionString()));

            services.Configure<RedisCacheOptions>(options =>
                options.Configuration = _redisContainer.GetConnectionString());

            var keycloakAddress = _keycloakContainer.GetBaseAddress();

            services.Configure<KeycloakOptions>(options =>
            {
                options.AdminUrl = $"{keycloakAddress}admin/realms/northstar/";
                options.TokenUrl = $"{keycloakAddress}realms/northstar/protocol/openid-connect/token";
            });

            services.Configure<AuthenticationOptions>(o =>
            {
                o.Issuer = $"{keycloakAddress}realms/northstar/";
                o.MetadataUrl = $"{keycloakAddress}realms/northstar/.well-known/openid-configuration";
            });
        });
    }

    public async Task InitializeAsync()
    {
        await _postgresSqlContainer.StartAsync();
        await _redisContainer.StartAsync();
        await _keycloakContainer.StartAsync();

        await InitializeTestUserAsync();
    }

    public new async Task DisposeAsync()
    {
        await _postgresSqlContainer.StopAsync();
        await _redisContainer.StopAsync();
        await _keycloakContainer.StopAsync();
    }

    private async Task InitializeTestUserAsync()
    {
        try
        {
            var httpClient = CreateClient();

            await httpClient.PostAsJsonAsync("api/v1/people", PeopleData.PersonRequest);
        }
        catch (Exception)
        {

            throw;
        }
    }
}
