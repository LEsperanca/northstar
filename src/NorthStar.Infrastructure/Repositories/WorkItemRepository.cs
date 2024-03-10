using NorthStar.Domain.WorkItems;
using NorthStar.Domain.WorkItems.Repository;

namespace NorthStar.Infrastructure.Repositories;
internal sealed class WorkItemRepository : Repository<WorkItem>, IWorkItemRepository
{
    public WorkItemRepository(NorthStarEfCoreDbContext dbContext) : base(dbContext)
    {
    }
}
