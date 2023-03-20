namespace FoxBreakfast.Services.Breakfast;

public interface IBreakfastService
{
   void CreateBreakfast(Models.Breakfast breakfast);
   Models.Breakfast GetBreakfast(Guid id);
}