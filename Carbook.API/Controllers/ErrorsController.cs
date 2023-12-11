using Microsoft.AspNetCore.Mvc;

namespace Carbook.API.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}