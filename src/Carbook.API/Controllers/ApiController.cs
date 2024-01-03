using FazApp.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

        if (errors.All(e => e.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);
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
    
    protected IActionResult ValidationProblem(List<Error> errors)
    {
        ModelStateDictionary modelStateDictionary = new ();

        foreach (Error error in errors)
        {
            modelStateDictionary.AddModelError(
                error.Code,
                error.Description);
        }

        return ValidationProblem(modelStateDictionary);
    }
}