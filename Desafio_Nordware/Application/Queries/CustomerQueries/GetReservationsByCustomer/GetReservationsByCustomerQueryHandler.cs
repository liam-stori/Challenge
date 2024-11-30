using App.Core.Entities;
using App.Infrastructure.Context;
using App.Shared.Results;
using MediatR;
using NHibernate.Linq;

namespace App.Application.Queries.CustomerQueries.GetReservationsByCustomer;

public class GetReservationsByCustomerQueryHandler
    : QueryHandler<List<Dtos.GetReservationsByCustomer>>,
    IRequestHandler<GetReservationsByCustomerQuery, HttpResultResponse<List<Dtos.GetReservationsByCustomer>>>
{
    public GetReservationsByCustomerQueryHandler(
        IAppDbContext context) : base(context) { }

    public async Task<HttpResultResponse<List<Dtos.GetReservationsByCustomer>>> Handle(GetReservationsByCustomerQuery request,
        CancellationToken cancellationToken)
    {
        var id = request.Id;

        if (id < 1)
            return Warning(StatusCodes.Status400BadRequest, $"The value entered was {id}. The Customer ID must be greater than zero.");

        var customerExists = await CustomerExists(id);

        if (!customerExists)
            return Warning(StatusCodes.Status404NotFound, $"The Customer ID {id} does not exist.");

        var products = await Context.Query<Customer>()
            .Where(c => c.Id == id)
            .SelectMany(c => c.Reservations)
            .Select(r => new Dtos.GetReservationsByCustomer
            {
                NameProduct = r.Product.Name,
                CategoryProduct = r.Product.Category,
                PriceForProduct = r.Product.Price,
                TotalPrice = r.Product.Price * r.Quantity,
                QuantityReservation = r.Quantity,
                ReservedAt = r.ReservedAt,
                StatusReservation = r.Status.Name,
            })
            .ToListAsync(cancellationToken);

        return Success(StatusCodes.Status200OK, products);
    }

    private async Task<bool> CustomerExists(long id)
    {
        return await Context.Query<Customer>()
            .AnyAsync(c => c.Id == id);
    }
}
