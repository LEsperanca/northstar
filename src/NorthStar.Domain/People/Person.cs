namespace NorthStar.Domain.People;

using NorthStar.Domain.Abstractions;

public class Person : Entity
{
    private readonly List<Role> _roles = new();

    public Name Name { get; private set; }

    public Address? Address { get; private set; }

    public Email Email { get; private set; }
    
    public PersonRole PersonRole { get; private set; }

    public string IdentityId { get; private set; } = string.Empty;

    public void SetIdentityId(string id)
    {
        IdentityId = id;
    }

    public IReadOnlyCollection<Role> Roles => _roles.ToList();

    private Person()
    {
        Name = null!;
        Email = null!;
    }

    private Person(Guid id, Name name, PersonRole role, Address? address, Email email) : base(id)
    {
        PersonRole = role;
        Address = address;
        Email = email;
        Name = name;
    }

    public static Person Create(string name, string email)
    {
        var person = new Person(Guid.NewGuid(), new Name(name), PersonRole.None, null, new Email(email));

        person._roles.Add(Role.Registered);

        return person;
    }
}