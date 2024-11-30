using App.Core.Entities;
using App.Infrastructure.Context;
using App.Shared.Results;
using MediatR;

namespace App.Application.Commands.CustomerCommands.ReserveProduct;

public class ReserveProductCommandHandler : CommandHandler,
    IRequestHandler<ReserveProductCommand, HttpResult>
{
    public ReserveProductCommandHandler(IAppDbContext context)
        : base(context) { }

    public async Task<HttpResult> Handle(ReserveProductCommand request,
        CancellationToken cancellationToken)
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

        if (!product.CanBeReserved())
            return HttpWarning(StatusCodes.Status409Conflict, "The Product out of stock.");

        var response = await ProcessReserve(customer, product);

        if (product.Quantity > 0)
            product.RemoveQuantity(1);
        else
            product.DefineTemporarilyUnavailable();

        await Context.Customers.UpdateAsync(customer);
        await Context.Products.UpdateAsync(product);

        return HttpSuccess(response);
    }

    private async Task<int> ProcessReserve(Customer customer, Product product)
    {
        var reservation = customer.Reservations
            .FirstOrDefault(x => x.Id == product.Id);

        if (reservation != null)
        {
            if (reservation.IsReserved())
                reservation.AddQuantity();
            else
                reservation.RestartQuantity();

            await Context.Reservations.UpdateAsync(reservation);

            return StatusCodes.Status204NoContent;
        }
        else
        {
            reservation = new Reservation(product, customer);
            customer.AddReservation(reservation);

            await Context.Reservations.AddAsync(reservation);

            return StatusCodes.Status201Created;
        }
    }
}
