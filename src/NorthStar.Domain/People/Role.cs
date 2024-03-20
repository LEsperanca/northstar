namespace NorthStar.Domain.People;
public sealed class Role
{
    public static readonly Role Registered = new(1, "Registered");

    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public Role(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public ICollection<Person> People { get; init; } = [];

    public ICollection<Permission> Permissions { get; init; } = [];
}
