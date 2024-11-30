using App.Application.Queries.ProductsQueries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(IMediator mediator) : BaseController
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Obtain all products
    /// </summary>
    /// <returns>Returns list of all products</returns>
    /// <response code="200">Returns list even if empty</response>
    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetProducts()
    {
        var result = await _mediator.Send(new GetProductsQuery());

        return HandleResult(result, result.Value);
    }
}
