using ErrorOr;
using FoxBreakfast.ServiceError;

namespace FoxBreakfast.Services.Breakfast;

public class BreakfastService : IBreakfastService
{
   private readonly Dictionary<Guid, Models.Breakfast> _breakfasts = new();
   public ErrorOr<Created> CreateBreakfast(Models.Breakfast breakfast)
   {
      _breakfasts.Add(breakfast.Id, breakfast);

      return Result.Created;
   }

   public ErrorOr<Deleted> DeleteBreakfast(Guid id)
   {
      _breakfasts.Remove(id);

      return Result.Deleted;
   }

   public ErrorOr<Models.Breakfast> GetBreakfast(Guid id)
   {
      if (_breakfasts.TryGetValue(id, out var breakfast))
      {
         return breakfast;
      }
      return ErrorInstance.Breakfast.NotFound;
   }

   public ErrorOr<UpsertedBreakfast> UpsertBreakfast(Models.Breakfast breakfast)
   {
      var IsNewlyCreated = !_breakfasts.ContainsKey(breakfast.Id);
      _breakfasts[breakfast.Id] = breakfast;

      return new UpsertedBreakfast(IsNewlyCreated);
   }
}