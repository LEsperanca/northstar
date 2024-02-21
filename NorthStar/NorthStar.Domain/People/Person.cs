namespace NorthStar.Domain.People;

using NorthStar.Domain.Abstractions;
using NorthStar.Domain.Shared;

public class Person : Entity
{

    public Person(Guid id, Name name, Role role, Address address, Email email) : base(id)
    {
        Role = role;
        Address = address;
        Email = email;
        Name = name;
    }

    public Name Name { get; private set; }

    public Address Address { get; private set; }

    public Email Email { get; private set; }
    
    public Role Role { get; private set; }
}