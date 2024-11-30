using App.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

public class BaseController : ControllerBase
{
    protected ActionResult HandleResult(ResultBase result)
    {
        return result.StatusCode switch
        {
            StatusCodes.Status200OK => Ok(),
            StatusCodes.Status201Created => Created(string.Empty, result.ErrorMessage),
            StatusCodes.Status204NoContent => NoContent(),
            StatusCodes.Status400BadRequest => BadRequest(result.ErrorMessage),
            StatusCodes.Status404NotFound => NotFound(result.ErrorMessage),
            StatusCodes.Status409Conflict => Conflict(result.ErrorMessage),
            StatusCodes.Status500InternalServerError => StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage),
            _ => StatusCode(result.StatusCode, result.ErrorMessage),
        };
    }

    protected ActionResult HandleResult<T>(ResultBase result, T content)
    {
        return result.StatusCode switch
        {
            StatusCodes.Status200OK => Ok(content),
            StatusCodes.Status201Created => Created(string.Empty, content),
            StatusCodes.Status204NoContent => NoContent(),
            StatusCodes.Status400BadRequest => BadRequest(result.ErrorMessage),
            StatusCodes.Status404NotFound => NotFound(result.ErrorMessage),
            StatusCodes.Status409Conflict => Conflict(result.ErrorMessage),
            StatusCodes.Status500InternalServerError => StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage),
            _ => StatusCode(result.StatusCode, result.ErrorMessage),
        };
    }
}
