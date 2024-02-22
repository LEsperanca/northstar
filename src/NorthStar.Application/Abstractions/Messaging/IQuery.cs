namespace NorthStar.Application.Abstractions.Messaging;

using MediatR;
using NorthStar.Domain.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}