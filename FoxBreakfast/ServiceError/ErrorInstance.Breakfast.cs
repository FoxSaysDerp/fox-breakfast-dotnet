using ErrorOr;

namespace FoxBreakfast.ServiceError;

public static class ErrorInstance
{
   public static class Breakfast
   {
      public static Error InvalidName => Error.Validation(
         code: "Breakfast.InvalidName",
         description: $"Breakfast name must be between {Models.Breakfast.MIN_NAME_LENGTH} and {Models.Breakfast.MAX_NAME_LENGTH} charactrs long."
      );
      public static Error InvalidDescription => Error.Validation(
         code: "Breakfast.InvalidDescription",
         description: $"Breakfast description must be between {Models.Breakfast.MIN_DESCRIPTION_LENGTH} and {Models.Breakfast.MAX_DESCRIPTION_LENGTH} charactrs long."
      );
      public static Error NotFound => Error.NotFound(
         "Breakfast.NotFound",
         "Breakfast not found"
      );
   }
}