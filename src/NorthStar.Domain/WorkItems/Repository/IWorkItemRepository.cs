namespace NorthStar.Domain.WorkItems.Repository;
public interface IWorkItemRepository
{
    void Add(WorkItem person);

    Task<WorkItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Update(WorkItem person);

    void Delete(WorkItem person);
}
