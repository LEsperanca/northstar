namespace NorthStar.Application.Persons.Create;
public record PersonRequest(
    string Email, 
    string Name, 
    string Password);
