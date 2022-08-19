#pragma warning disable CS8765
#pragma warning disable CS8603
using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;
[NotMapped]
public class AddressValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (Regex.Match( (string) value, @"\d{1,6}\s(?:[A-Za-z0-9#]+\s){0,7}(?:[A-Za-z0-9#])\s*(?:[A-Za-z]+\s){0,3}(?:[A-Za-z]+,)\s*[A-Z]{2}\s*\d{5}" ).Success) 
        {
            return ValidationResult.Success;
        }
        
        return new ValidationResult(
            $"This is not a valid address!"
        );
}
}
