using App.Shared.Results;
using MediatR;

namespace App.Application.Queries.ProductsQueries.GetProducts;

public class GetProductsQuery()
    : IRequest<HttpResultResponse<List<Dtos.GetProducts>>>
{
}
