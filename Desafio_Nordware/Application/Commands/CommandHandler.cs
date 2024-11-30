using App.Infrastructure.Context;
using App.Shared.Results;
using MediatR;

namespace App.Application.Commands;

public class CommandHandler : HandlerBase
{
    public CommandHandler(IAppDbContext context)
        : base(context) { }

    public CommandHandler(IAppDbContext context, IMediator mediator)
        : base(context, mediator) { }


    protected HttpResult HttpSuccess(int statusCode)
    {
        return HttpResult.Success(statusCode);
    }

    protected HttpResult HttpWarning(int statusCode, string message)
    {
        return HttpResult.Warning(statusCode, message);
    }

    protected HttpResult HttpFailure(int statusCode, string message)
    {
        return HttpResult.Failure(statusCode, message);
    }
}
