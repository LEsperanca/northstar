namespace NorthStar.Application.Abstractions.Messaging;

using MediatR;
using NorthStar.Domain.Abstractions;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}