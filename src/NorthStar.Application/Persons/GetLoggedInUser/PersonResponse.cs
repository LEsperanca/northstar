namespace NorthStar.Application.Persons.GetLoggedInUser;
public sealed class PersonResponse
{
    public Guid Id { get; init; }

    public string Email { get; init; } 

    public string Name { get; init; }


    public PersonResponse(Guid id, string name, string email)
    {
        Id = id;
        Email = email;
        Name = name;
    }
}
