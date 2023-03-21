using ErrorOr;
using FoxBreakfast.Contracts.Breakfast;
using FoxBreakfast.Models;
using FoxBreakfast.Services.Breakfast;
using Microsoft.AspNetCore.Mvc;

namespace FoxBreakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastController : ApiController
{
   private readonly IBreakfastService _breakfastService;
   public BreakfastController(IBreakfastService breakfastService)
   {
      _breakfastService = breakfastService;
   }

   [HttpGet("{id:guid}")]
   public IActionResult GetBreakfast(Guid id)
   {
      ErrorOr<Breakfast> getBreakfastResult = _breakfastService.GetBreakfast(id);
      return getBreakfastResult.Match(
         breakfast => Ok(MapBreakfastResponse(breakfast)),
         errors => Problem(errors)
      );
   }

   private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
   {
      return new BreakfastResponse(
         breakfast.Id,
         breakfast.Name,
         breakfast.Description,
         breakfast.StartDateTime,
         breakfast.EndDateTime,
         breakfast.LastModifiedDateTime,
         breakfast.Savory,
         breakfast.Sweet
      );
   }

   [HttpPost]
   public IActionResult CreateBreakfast(CreateBreakfastRequest request)
   {
      ErrorOr<Breakfast> requestToBreakfastResult = Breakfast.Create(
         request.Name,
         request.Description,
         request.StartDateTime,
         request.EndDateTime,
         request.Savory,
         request.Sweet
      );

      if (requestToBreakfastResult.IsError)
      {
         return Problem(requestToBreakfastResult.Errors);
      }

      var breakfast = requestToBreakfastResult.Value;

      ErrorOr<Created> createBreakfastResult = _breakfastService.CreateBreakfast(breakfast);

      return createBreakfastResult.Match(
         created => CreatedAtGetBreakfast(breakfast),
         errors => Problem(errors)
      );
   }

   [HttpPut("{id:guid}")]
   public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
   {
      ErrorOr<Breakfast> requestToBreakfast = Breakfast.Create(
         request.Name,
         request.Description,
         request.StartDateTime,
         request.EndDateTime,
         request.Savory,
         request.Sweet,
         id
      );
      if (requestToBreakfast.IsError) {
         return Problem(requestToBreakfast.Errors);
      }
      var breakfast = requestToBreakfast.Value;

      ErrorOr<UpsertedBreakfast> upsertBreakfastResult = _breakfastService.UpsertBreakfast(breakfast);

      return upsertBreakfastResult.Match(
         upserted => upserted.IsNewlyCreated ? CreatedAtGetBreakfast(breakfast) : NoContent(),
         errors => Problem(errors)
      );
   }

   [HttpDelete("{id:guid}")]
   public IActionResult DeleteBreakfast(Guid id)
   {
      ErrorOr<Deleted> deleteBreakfastResult = _breakfastService.DeleteBreakfast(id);

      return deleteBreakfastResult.Match(
         deleted => NoContent(),
         errors => Problem(errors));
   }

   private CreatedAtActionResult CreatedAtGetBreakfast(Breakfast breakfast)
   {
      return CreatedAtAction(
               nameof(GetBreakfast),
               new { id = breakfast.Id },
               MapBreakfastResponse(breakfast));
   }
}