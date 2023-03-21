using ErrorOr;
using FoxBreakfast.ServiceError;

namespace FoxBreakfast.Models;

public class Breakfast
{
   public const int MIN_NAME_LENGTH = 3;
   public const int MAX_NAME_LENGTH = 50;
   
   public const int MIN_DESCRIPTION_LENGTH = 50;
   public const int MAX_DESCRIPTION_LENGTH = 150;
   public Guid Id {get;}
   public string Name {get;}
   public string Description {get;}
   public DateTime StartDateTime {get;}
   public DateTime EndDateTime {get;}
   public DateTime LastModifiedDateTime {get;}
   public List<string> Savory {get;}
   public List<string> Sweet {get;}

   private Breakfast(Guid id,
                    string name,
                    string description,
                    DateTime startDateTime,
                    DateTime endDateTime,
                    DateTime lastModifiedDateTime,
                    List<string> savory,
                    List<string> sweet)
   {
      Id = id;
      Name = name;
      Description = description;
      StartDateTime = startDateTime;
      EndDateTime = endDateTime;
      LastModifiedDateTime = lastModifiedDateTime;
      Savory = savory;
      Sweet = sweet;
   }

   public static ErrorOr<Breakfast> Create(
      string name,
      string description,
      DateTime startDateTime,
      DateTime endDateTime,
      List<string> savory,
      List<string> sweet,
      Guid? id = null
   )
   {
      List<Error> errors = new();

      if (name.Length is < MIN_NAME_LENGTH or > MAX_NAME_LENGTH)
      {
         errors.Add(ErrorInstance.Breakfast.InvalidName);
      }
      if (description.Length is < MIN_DESCRIPTION_LENGTH or > MAX_DESCRIPTION_LENGTH)
      {
         errors.Add(ErrorInstance.Breakfast.InvalidDescription);
      }
      if (errors.Count > 0) {
         return errors;
      }
      return new Breakfast(
         id ?? Guid.NewGuid(),
         name,
         description,
         startDateTime,
         endDateTime,
         DateTime.UtcNow,
         savory,
         sweet
      );
   }
}