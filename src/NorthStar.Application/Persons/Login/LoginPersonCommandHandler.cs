using NorthStar.Application.Abstractions.Authentication;
using NorthStar.Application.Abstractions.Messaging;
using NorthStar.Domain.Abstractions;
using NorthStar.Domain.People;

namespace NorthStar.Application.Persons.Login;
internal sealed class LoginPersonCommandHandler : ICommandHandler<LoginPersonComand, AccessTokenResponse>
{
    private readonly IJwtService _jwtService;

    public LoginPersonCommandHandler(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    public async Task<Result<AccessTokenResponse>> Handle(LoginPersonComand request, CancellationToken cancellationToken)
    {
        var result = await _jwtService.GetAccessTokenAsync(request.Email, request.Password, cancellationToken);

        if (result.IsFailure) 
        {
            return Result.Failure<AccessTokenResponse>(PersonErrors.InvalidCredentials);
        }

        return new AccessTokenResponse(result.Value);
    }
}
