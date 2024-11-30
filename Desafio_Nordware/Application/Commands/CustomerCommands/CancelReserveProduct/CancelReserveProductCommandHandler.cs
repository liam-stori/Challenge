using App.Core.Entities;
using App.Core.Enumerators;
using App.Infrastructure.Context;
using App.Shared.Results;
using MediatR;
using NHibernate.Linq;

namespace App.Application.Commands.CustomerCommands.CancelReserveProduct;

public class CancelReserveProductCommandHandler : CommandHandler,
    IRequestHandler<CancelReserveProductCommand, HttpResult>
{
    public CancelReserveProductCommandHandler(IAppDbContext context)
        : base(context) { }

    public async Task<HttpResult> Handle(CancelReserveProductCommand request, CancellationToken cancellationToken)
    {
        if (request.Id < 1 || request.IdProduct < 1)
            return HttpWarning(StatusCodes.Status400BadRequest, $"The input values were ID Customer: {request.Id} / ID Product: {request.IdProduct}. The input values must be greater than zero.");

        var id = request.Id;
        var idProduct = request.IdProduct;

        var customer = await Context.Customers.GetByIdAsync(id);
        if (customer == null)
            return HttpWarning(StatusCodes.Status404NotFound, $"The Customer ID {id} does not exist.");

        var product = await Context.Products.GetByIdAsync(idProduct);
        if (product == null)
            return HttpWarning(StatusCodes.Status404NotFound, $"The Product ID {idProduct} does not exist.");

        if (!CustomerHasReservation(customer, idProduct))
            return HttpWarning(StatusCodes.Status404NotFound, $"The Customer ID {id} has no reservation for Product ID {idProduct}.");

        var quantityCancel = await ProcessCancel(customer, idProduct);

        product.AddQuantity(quantityCancel);

        var productReservations = await ProductReservations(idProduct);

        if (product.Status.IsTemporarilyUnavailable() && productReservations > 0)
            product.RemoveQuantity(productReservations);

        await Context.Products.UpdateAsync(product);

        return HttpSuccess(StatusCodes.Status204NoContent);
    }

    private static bool CustomerHasReservation(Customer customer, long idProduct)
    {
        return customer.Reservations
            .Where(x => x.Status.Id == (short)ReservationStatusEnum.Reserved)
            .Any(x => x.Product.Id == idProduct);
    }

    private async Task<int> ProductReservations(long idProduct)
    {
        return await Context.Query<Reservation>()
            .Where(x => x.Status.Id == (short)ReservationStatusEnum.Reserved)
            .CountAsync(x => x.Product.Id == idProduct);
    }

    private async Task<int> ProcessCancel(Customer customer, long idProduct)
    {
        var reservation = customer.Reservations
            .Single(x => x.Id == idProduct);

        var quantityReservation = reservation.Quantity;

        reservation.Cancel();

        await Context.Reservations.UpdateAsync(reservation);

        return quantityReservation;
    }
}
