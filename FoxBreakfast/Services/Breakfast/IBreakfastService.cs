using ErrorOr;

namespace FoxBreakfast.Services.Breakfast;

public interface IBreakfastService
{
   ErrorOr<Created> CreateBreakfast(Models.Breakfast breakfast);
   ErrorOr<Models.Breakfast> GetBreakfast(Guid id);
   ErrorOr<Deleted> DeleteBreakfast(Guid id);
   ErrorOr<UpsertedBreakfast> UpsertBreakfast(Models.Breakfast breakfast);
}