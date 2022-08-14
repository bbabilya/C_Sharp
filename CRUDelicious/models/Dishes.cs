#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CRUDelicious.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Name: ")]
    public string Name { get; set; } 

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Chef: ")]
    public string Chef { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Tastiness: ")]
    [RegularExpression("([1-5]+)", ErrorMessage = "Must be between 1-5.")]
    public int Tastiness { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Calories: ")]
    [Range(0, int.MaxValue, ErrorMessage = "Please enter a value greater than {0}.")]
    public int Calories { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Description: ")]
    public string Description { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
