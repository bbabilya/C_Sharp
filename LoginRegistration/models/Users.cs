#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LoginRegistration.Models;
public class User
{
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "First Name: ")]
    public string FirstName { get; set; } 

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Last Name: ")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Email: ")]
    [EmailAddress(ErrorMessage = "Must be a valid e-mail.")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Required]
    [Display(Name = "Password: ")]
    [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
    public string Password { get; set; } 

    [NotMapped]
    [Compare("Password")]
    [Display(Name = "Confirm Password: ")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } 

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
