namespace WeddingPlanner.Models;

#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class User_Wedding_RSVP
{
    [Key]
    public int UserWeddingRSVPId { get; set; }
    public int UserId {get; set;}
    public int WeddingId {get; set;}
    public User? User {get; set;}
    public Wedding? Wedding {get; set;}

}
