namespace ProductsandCategories.Models;

#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Name: ")]
    public string Name { get; set; } 

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Description: ")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Price: ")]
    public float Price { get; set; }

    public List<Association> ListedCategories { get; set; } = new List<Association>();

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
