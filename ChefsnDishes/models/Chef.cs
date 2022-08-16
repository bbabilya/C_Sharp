#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsnDishes.Models;
public class Chef
{
    public int Age()
    {
        return DateTime.Now.Year - Birthdate.Year;
    }

    [Key]
    public int ChefId { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "First Name: ")]
    public string FirstName { get; set; } 

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Last Name: ")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Birthdate: ")]
    [AgeVerification]
    public DateTime Birthdate { get; set; }

    public List<Dish> CreatedDishes { get; set; } = new List<Dish>(); 

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
