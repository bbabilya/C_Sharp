namespace ChefsnDishes.Models;

#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Name: ")]
    public string Name { get; set; } 

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Calories: ")]
    public int Calories { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Description: ")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Tastiness: ")]
    public int Tastiness { get; set; }

    [Required]
    public int ChefId { get; set; }

    public Chef? Chef {get; set;}

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
