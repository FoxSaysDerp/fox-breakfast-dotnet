using FoxBreakfast.Contracts.Breakfast;
using FoxBreakfast.Models;
using FoxBreakfast.Services.Breakfast;
using Microsoft.AspNetCore.Mvc;

namespace FoxBreakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastController : ControllerBase
{
   private readonly IBreakfastService _breakfastService;
   public BreakfastController(IBreakfastService breakfastService)
   {
      _breakfastService = breakfastService;
   }

   [HttpGet("{id:guid}")]
   public IActionResult GetBreakfast(Guid id)
   {
      Breakfast breakfast = _breakfastService.GetBreakfast(id);
      var response = new BreakfastResponse(
         breakfast.Id,
         breakfast.Name,
         breakfast.Description,
         breakfast.StartDateTime,
         breakfast.EndDateTime,
         breakfast.LastModifiedDateTime,
         breakfast.Savory,
         breakfast.Sweet
      );
      return Ok(response);
   }

   [HttpPost]
   public IActionResult CreateBreakfast(CreateBreakfastRequest request)
   {
      var breakfast = new Breakfast(
         Guid.NewGuid(),
         request.Name,
         request.Description,
         request.StartDateTime,
         request.EndDateTime,
         DateTime.Now,
         request.Savory,
         request.Sweet
      );

      _breakfastService.CreateBreakfast(breakfast);

      var response = new BreakfastResponse(
         breakfast.Id,
         breakfast.Name,
         breakfast.Description,
         breakfast.StartDateTime,
         breakfast.EndDateTime,
         breakfast.LastModifiedDateTime,
         breakfast.Savory,
         breakfast.Sweet
      );
      return CreatedAtAction(
         nameof(GetBreakfast),
         new { id = breakfast.Id},
         request);
   }

   [HttpPut("{id:guid}")]
   public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
   {
      return Ok();
   }

   [HttpDelete("{id:guid}")]
   public IActionResult DeleteBreakfast(Guid id)
   {
      return Ok();
   }
}