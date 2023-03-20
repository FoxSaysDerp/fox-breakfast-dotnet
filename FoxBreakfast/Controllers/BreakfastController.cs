using FoxBreakfast.Contracts.Breakfast;
using Microsoft.AspNetCore.Mvc;

namespace FoxBreakfast.Controllers;

[ApiController]
public class BreakfastController : ControllerBase
{
   [HttpGet("/breakfast/{id:guid}")]
   public IActionResult GetBreakfast(Guid id)
   {
      return Ok(id);
   }

   [HttpPost("/breakfast")]
   public IActionResult CreateBreakfast(CreateBreakfastRequest request)
   {
      return Ok();
   }

   [HttpPut("/breakfast/{id:guid}")]
   public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
   {
      return Ok();
   }

   [HttpDelete("/breakfast/{id:guid}")]
   public IActionResult DeleteBreakfast(Guid id)
   {
      return Ok();
   }
}