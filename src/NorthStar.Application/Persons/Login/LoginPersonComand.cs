using NorthStar.Application.Abstractions.Messaging;

namespace NorthStar.Application.Persons.Login;
public record LoginPersonComand(string Email, string Password) : ICommand<AccessTokenResponse>;
