using NorthStar.Domain.People;
using NorthStar.Domain.People.Repository;

namespace NorthStar.Infrastructure.Repositories;
internal sealed class PeopleRepository : Repository<Person>, IPeopleRepository
{
    public PeopleRepository(NorthStarEfCoreDbContext dbContext) : base(dbContext)
    {
    }
}
