using ErrorOr;
using FoxBreakfast.ServiceError;

namespace FoxBreakfast.Services.Breakfast;

public class BreakfastService : IBreakfastService
{
   private readonly Dictionary<Guid, Models.Breakfast> _breakfasts = new();
   public void CreateBreakfast(Models.Breakfast breakfast)
   {
      _breakfasts.Add(breakfast.Id, breakfast);
   }

   public void DeleteBreakfast(Guid id)
   {
      _breakfasts.Remove(id);
   }

   public ErrorOr<Models.Breakfast> GetBreakfast(Guid id)
   {
      if (_breakfasts.TryGetValue(id, out var breakfast))
      {
         return breakfast;
      }
      return ErrorInstance.Breakfast.NotFound;
   }

   public void UpsertBreakfast(Models.Breakfast breakfast)
   {
      _breakfasts[breakfast.Id] = breakfast;
   }
}