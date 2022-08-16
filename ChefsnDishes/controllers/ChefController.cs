// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsnDishes.Models;
namespace ChefsnDishes.Controllers;
    
public class ChefController : Controller
{
    private MyContext _context;
    public ChefController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {

        List<Chef> CreatedChefs = new List<Chef>(); 
        List<Chef> AllChefs = _context.Chefs.ToList();
        ViewBag.Chefs = AllChefs;

        return View("ChefIndex", AllChefs);
    }

    [HttpGet("new")]
    public IActionResult ChefForm()
    {
        return View("ChefForm");
    }


    [HttpPost("chef/submission")]
    public IActionResult ChefSubmission(Chef chef)
    {
        if(ModelState.IsValid)
        {
            chef.UpdatedAt = DateTime.Now;
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("ChefForm");
    }
}


