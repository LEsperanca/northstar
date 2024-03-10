using NorthStar.Domain.Projects;
using NorthStar.Domain.Projects.Repository;

namespace NorthStar.Infrastructure.Repositories;
internal sealed class ProjectRepository : Repository<Project>, IProjectRepository
{
    public ProjectRepository(NorthStarEfCoreDbContext dbContext) : base(dbContext)
    {
    }
}
