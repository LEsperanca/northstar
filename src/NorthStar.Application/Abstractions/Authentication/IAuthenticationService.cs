using NorthStar.Domain.People;

namespace NorthStar.Application.Abstractions.Authentication;
public interface IAuthenticationService
{
    Task<string> RegisterAsync(
        Person person, 
        string password,
        CancellationToken cancellationToken = default);
}
