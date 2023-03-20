using Microsoft.AspNetCore.Mvc;

namespace FoxBreakfast.Controllers;

public class ErrorController : ControllerBase
{
   [ApiExplorerSettings(IgnoreApi = true)]
   [Route("/error")]
   public IActionResult Error()
   {
      return Problem();
   }
}