using FazApp.Result;
using Microsoft.AspNetCore.Mvc;

namespace Carbook.API.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count == 0)
        {
            return Problem();
        }

        return Problem(errors[0]);
    }
    
    protected IActionResult Problem(Error error)
    {
        int statusCode = error.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };
        
        return Problem(statusCode: statusCode, detail: error.Description);
    }
}