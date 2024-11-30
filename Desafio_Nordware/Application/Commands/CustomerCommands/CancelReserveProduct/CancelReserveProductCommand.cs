using App.Shared.Results;
using MediatR;

namespace App.Application.Commands.CustomerCommands.CancelReserveProduct;

public class CancelReserveProductCommand(long id, long idProduct)
    : IRequest<HttpResult>
{
    public long Id { get; } = id;

    public long IdProduct { get; } = idProduct;
}
