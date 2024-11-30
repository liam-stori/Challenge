using App.Core.Entities;
using App.Infrastructure.Context;
using App.Shared.Results;
using MediatR;
using NHibernate.Linq;

namespace App.Application.Queries.ProductsQueries.GetProducts;

public class GetProductsQueryHandler
    : QueryHandler<List<Dtos.GetProducts>>,
    IRequestHandler<GetProductsQuery, HttpResultResponse<List<Dtos.GetProducts>>>
{
    public GetProductsQueryHandler(IAppDbContext context)
        : base(context) { }

    public async Task<HttpResultResponse<List<Dtos.GetProducts>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await Context.Query<Product>()
            .Select(p => new Dtos.GetProducts
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                Description = p.Description,
                Quantity = p.Quantity,
                Price = p.Price,
                NameStatus = p.Status.Name
            })
            .ToListAsync(cancellationToken);

        return Success(StatusCodes.Status200OK, products);
    }
}
