namespace NorthStar.Domain.People.Repository;
public interface IPeopleRepository
{
    void Add(Person person);

    Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Update(Person person);

    void Delete(Person person);
}
