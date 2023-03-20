namespace FoxBreakfast.Services.Breakfast;

public class BreakfastService : IBreakfastService
{
   private readonly Dictionary<Guid, Models.Breakfast> _breakfasts = new();
   public void CreateBreakfast(Models.Breakfast breakfast)
   {
      _breakfasts.Add(breakfast.Id, breakfast);
   }

   public Models.Breakfast GetBreakfast(Guid id)
   {
      return _breakfasts[id];
   }
}