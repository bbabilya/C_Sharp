#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;
public class Wedding
{
    [Key]
    public int WeddingId { get; set; }
    public int UserId { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Wedder One: ")]
    public string WedderOne { get; set; } 

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Wedder Two: ")]
    public string WedderTwo { get; set; }

    [Required(ErrorMessage = "Required field.")]
    [Display(Name = "Date: ")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage="Please enter an address!")]
    [Display(Name = "Address: ")]
    [AddressValidation]
    public string Address { get; set; } 
    public List<User_Wedding_RSVP> Guests { get; set; } = new List<User_Wedding_RSVP>();

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
