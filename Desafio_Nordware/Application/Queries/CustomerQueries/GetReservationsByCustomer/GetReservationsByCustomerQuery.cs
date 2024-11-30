using App.Shared.Results;
using MediatR;

namespace App.Application.Queries.CustomerQueries.GetReservationsByCustomer;

public class GetReservationsByCustomerQuery(long id)
    : IRequest<HttpResultResponse<List<Dtos.GetReservationsByCustomer>>>
{
    public long Id { get; } = id;
}
