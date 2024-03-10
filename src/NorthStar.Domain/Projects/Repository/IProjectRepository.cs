namespace NorthStar.Domain.Projects.Repository;
public interface IProjectRepository
{
    void Add(Project project);

    void Update(Project project);

    Task<Project?> GetByIdAsync(Guid projectId, CancellationToken cancellationToken = default);

    void Delete(Project project);


}
