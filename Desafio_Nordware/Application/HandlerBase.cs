using App.Infrastructure.Context;
using MediatR;

namespace App.Application;

public abstract class HandlerBase(IAppDbContext context)
{
    protected HandlerBase(IAppDbContext context, IMediator mediator)
        : this(context)
    {
        Mediator = mediator;
    }

    public IAppDbContext Context { get; } = context;
    public IMediator Mediator { get; } = null!;
}
