using Microsoft.AspNetCore.Mvc;

namespace FoxBreakfast.Controllers;

public class ErrorController : ControllerBase
{
   [Route("/error")]
   public IActionResult Error()
   {
      return Problem();
   }
}