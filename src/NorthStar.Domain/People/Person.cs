namespace NorthStar.Domain.People;

using NorthStar.Domain.Abstractions;

public class Person : Entity
{
    public Name Name { get; private set; }

    public Address? Address { get; private set; }

    public Email Email { get; private set; }
    
    public Role Role { get; private set; }

    public string IdentityId { get; private set; } = string.Empty;

    public void SetIdentityId(string id)
    {
        IdentityId = id;
    }

    private Person()
    {
        Name = null!;
        Email = null!;
    }

    private Person(Guid id, Name name, Role role, Address? address, Email email) : base(id)
    {
        Role = role;
        Address = address;
        Email = email;
        Name = name;
    }

    public static Person Create(string name, string email)
    {
        var person = new Person(Guid.NewGuid(), new Name(name), Role.None, null, new Email(email));

        return person;
    }
}