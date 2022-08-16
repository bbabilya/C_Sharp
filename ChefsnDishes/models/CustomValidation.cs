#pragma warning disable CS8765
#pragma warning disable CS8603

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsnDishes.Models;
[NotMapped]
public class AgeVerification : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        int current = DateTime.Now.Year;
        DateTime given = (DateTime)value;
        int age = current - given.Year;
        if(age < 18)
            return new ValidationResult("must be at least 18 years old");
        return ValidationResult.Success;
    }
}