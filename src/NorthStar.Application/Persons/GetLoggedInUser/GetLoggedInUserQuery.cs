using NorthStar.Application.Abstractions.Messaging;

namespace NorthStar.Application.Persons.GetLoggedInUser;
public sealed record GetLoggedInUserQuery : IQuery<PersonResponse>;
