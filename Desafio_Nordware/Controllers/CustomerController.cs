using App.Application.Commands.CustomerCommands.CancelReserveProduct;
using App.Application.Commands.CustomerCommands.ReserveProduct;
using App.Application.Queries.CustomerQueries.GetReservationsByCustomer;
using App.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController(IMediator mediator) : BaseController
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Obtain all products reserved by customers
    /// </summary>
    /// <param name="id">ID of the customer  to retrieve the list of reservations</param>
    /// <returns>Returns list of products reserved by the customer</returns>
    /// <response code="200">Returns list even if empty</response>
    /// <response code="400">Invalid Customer ID</response>
    /// <response code="404">Customer ID not found</response>
    [HttpGet("{id}/reservations")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Reservation>>> GetReservationsByCostumer(long id)
    {
        var result = await _mediator.Send(new GetReservationsByCustomerQuery(id));

        return HandleResult(result, result.Value);
    }

    /// <summary>
    /// Reserve one product by ID for a customer
    /// </summary>
    /// <param name="id">ID of the customer</param>
    /// <param name="idProduct">ID of the product to reserve</param>
    /// <response code="200">Reserved with sucess</response>
    /// <response code="400">Invalid Customer ID or Product ID</response>
    /// <response code="404">Customer ID or Product ID not found</response>
    /// <response code="409">Product is Out of Stock</response>
    [HttpPost("{id}/products/{idProduct}/reserve")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> ReserveProduct(long id, long idProduct)
    {
        var result = await _mediator.Send(new ReserveProductCommand(id, idProduct));

        return HandleResult(result);
    }

    /// <summary>
    /// Reserve one product by ID for a customer
    /// </summary>
    /// <param name="id">ID of the customer</param>
    /// <param name="idProduct">ID of the product to reserve</param>
    /// <response code="200">Reserved with sucess</response>
    /// <response code="400">Invalid Customer ID or Product ID</response>
    /// <response code="404">Customer ID or Product ID not found</response>
    /// <response code="409">Product is Out of Stock</response>
    [HttpPost("{id}/products/{idProduct}/cancel-reserve")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CancelReserveProduct(long id, long idProduct)
    {
        var result = await _mediator.Send(new CancelReserveProductCommand(id, idProduct));

        return HandleResult(result);
    }
}
