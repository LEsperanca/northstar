using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NorthStar.Application.Abstractions.Exceptions;
using NorthStar.Domain.Abstractions;

namespace NorthStar.Infrastructure;
public sealed class NorthStarEfCoreDbContext : DbContext, IUnitOfWork
{

    private readonly ILoggerFactory _loggerFactory;
    private readonly IPublisher _publisher;
    public NorthStarEfCoreDbContext(DbContextOptions dbContextOptions, 
        ILoggerFactory loggerFactory,
        IPublisher publisher) :base(dbContextOptions)
    {
        _loggerFactory = loggerFactory;
        _publisher = publisher;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory);
        optionsBuilder.EnableSensitiveDataLogging();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NorthStarEfCoreDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            await PublishDomainEventsAsync();

            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {

            throw new ConcurrencyException("Concurrency Exception Occurred", ex);
        }
    }

    private async Task PublishDomainEventsAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }
    }
}
