using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
namespace WeddingPlanner.Controllers;


public class WeddingController : Controller
{
    private int? id
    {
        get 
        {
            return HttpContext.Session.GetInt32("session");
        }
    }
    private MyContext _context;

    // here we can "inject" our context service into the constructor
    public WeddingController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        if(HttpContext.Session.GetInt32("session") != null )
        {
            List<Wedding> AllWeddings = _context.Weddings.Include(g => g.Guests).ToList();
            ViewBag.Weddings = AllWeddings;
            return View("WeddingIndex");

        }
        return RedirectToAction("Index", "Login");
    }

    [HttpGet("/wedding/{id}")]
    public IActionResult WeddingDetails(int id)
    {
        ViewBag.SingleWedding = _context.Weddings.Include(c => c.Guests).ThenInclude(u => u.User).FirstOrDefault(c => c.WeddingId == id);
        return View("WeddingDetails");
    }


    [HttpGet("/wedding/new")]
    public IActionResult WeddingForm()
    {
        if(HttpContext.Session.GetInt32("session") != null )
        {
            return View("WeddingForm");
        }
        return RedirectToAction("Index", "Login");
    }

    [HttpPost("wedding/new/submission")]
    public IActionResult WeddingSubmit(Wedding wedding)
    {
        if(ModelState.IsValid)
        {
            wedding.UserId = (int) id;
            wedding.UpdatedAt = DateTime.Now;
            _context.Weddings.Add(wedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        return WeddingForm();
    }

    [HttpGet("/{wedding_id}/add")]
    public IActionResult AddRSVP(int wedding_id)
    {
        User_Wedding_RSVP RSVPWedding = new User_Wedding_RSVP();
        RSVPWedding.UserId = (int) id;
        RSVPWedding.WeddingId = wedding_id;
        _context.User_Wedding_RSVPs.Add(RSVPWedding);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");   
    }

    [HttpGet("/{wedding_id}/remove")]
    public IActionResult RemoveRSVP(int wedding_id)
    {
    User_Wedding_RSVP? SingleWedding = _context.User_Wedding_RSVPs.SingleOrDefault(w => w.WeddingId == wedding_id && w.UserId == id);
    _context.User_Wedding_RSVPs.Remove(SingleWedding);
    _context.SaveChanges();
    return RedirectToAction("Dashboard");
    }


    [HttpGet("/{wedding_id}/delete")]
    public IActionResult DeleteDish(int wedding_id)
    {
    Wedding? SingleWedding = _context.Weddings.SingleOrDefault(w => w.WeddingId == wedding_id);
    _context.Weddings.Remove(SingleWedding);
    _context.SaveChanges();
    return RedirectToAction("Dashboard");
    }
}


