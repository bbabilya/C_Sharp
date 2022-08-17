namespace ProductsandCategories.Models;

#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Name: ")]
    public string Name { get; set; } 

    public List<Association> ListedProducts { get; set; } = new List<Association>();

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
