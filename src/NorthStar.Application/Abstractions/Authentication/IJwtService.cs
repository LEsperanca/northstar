using NorthStar.Domain.Abstractions;

namespace NorthStar.Application.Abstractions.Authentication;
public interface IJwtService
{
    Task<Result<string>> GetAccessTokenAsync(
        string email,
        string password,
        CancellationToken cancellationToken);
}
