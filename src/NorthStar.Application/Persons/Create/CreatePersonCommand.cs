using NorthStar.Application.Abstractions.Messaging;

namespace NorthStar.Application.Persons.Create;
public sealed record CreatePersonCommand(
    string Email, 
    string Name, 
    string Password) : ICommand<Guid>;

