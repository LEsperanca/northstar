namespace NorthStar.Domain.People;
public sealed class Permission
{
    public static readonly Permission PeopleRead = new(1, "people:read");

    public int Id { get; set; }

    public string Name { get; set; }

    public Permission(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
