using App.Infrastructure.Context;
using App.Shared.Results;
using MediatR;

namespace App.Application.Queries;

public class QueryHandler : HandlerBase
{
    public QueryHandler(IAppDbContext context)
        : base(context) { }

    public QueryHandler(IAppDbContext context, IMediator mediator)
        : base(context, mediator) { }
}

public abstract class QueryHandler<TResponse> : QueryHandler
{
    protected QueryHandler(IAppDbContext context)
        : base(context) { }

    protected QueryHandler(IAppDbContext context, IMediator mediator)
        : base(context, mediator) { }

    protected HttpResultResponse<TResponse> Success(int statusCode, TResponse response)
    {
        return HttpResultResponse<TResponse>.Success(statusCode, response);
    }

    protected HttpResultResponse<TResponse> Warning(int statusCode, string message)
    {
        return HttpResultResponse<TResponse>.Warning(statusCode, message);
    }

    protected HttpResultResponse<TResponse> Failure(int statusCode, string message)
    {
        return HttpResultResponse<TResponse>.Failure(statusCode, message);
    }
}