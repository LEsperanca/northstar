namespace NorthStar.Application.Abstractions.Messaging;

using MediatR;
using NorthStar.Domain.Abstractions;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}