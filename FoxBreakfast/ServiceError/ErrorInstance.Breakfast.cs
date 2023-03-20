using ErrorOr;

namespace FoxBreakfast.ServiceError;

public static class ErrorInstance
{
   public static class Breakfast
   {
      public static Error NotFound => Error.NotFound(
         "Breakfast.NotFound",
         "Breakfast not found"
      );
   }
}