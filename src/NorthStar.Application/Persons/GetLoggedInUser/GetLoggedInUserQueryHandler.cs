using Bookify.Application.Abstractions.Data;
using Dapper;
using NorthStar.Application.Abstractions.Authentication;
using NorthStar.Application.Abstractions.Messaging;
using NorthStar.Domain.Abstractions;
using System.Data;

namespace NorthStar.Application.Persons.GetLoggedInUser;
internal sealed class GetLoggedInUserQueryHandler : IQueryHandler<GetLoggedInUserQuery, PersonResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IUserContext _userContext;

    public GetLoggedInUserQueryHandler(ISqlConnectionFactory sqlConnectionFactory, IUserContext userContext)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _userContext = userContext;
    }

    public async Task<Result<PersonResponse>> Handle(GetLoggedInUserQuery request, CancellationToken cancellationToken)
    {
        using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                id AS Id,
                name AS Name,
                email AS Email
            FROM people
            WHERE identity_id = @IdentityId
            """;

        PersonResponse user = await connection.QuerySingleAsync<PersonResponse>(
            sql,
            new
            {
                _userContext.IdentityId
            });

        return user;
    }
}
