#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;
public class LoginUser
{
    [Required]
    [Display(Name = "Email: ")]
    public string EmailLogin { get; set; }
    [Required]
    [Display(Name = "Password: ")]
    public string PasswordLogin { get; set; } 
}