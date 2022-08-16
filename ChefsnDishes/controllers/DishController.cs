using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsnDishes.Models;
namespace ChefsnDishes.Controllers;
    
public class DishController : Controller
{
    private MyContext _context;
    public DishController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("dishes")]
public IActionResult DishIndex()
    {
        List<Dish> CreatedDishes = new List<Dish>(); 
        List<Dish> AllDishes = _context.Dishes.Include(d => d.Chef).ToList();
        ViewBag.Dishes = AllDishes;

        return View("DishIndex", AllDishes);
    }

    [HttpGet("/dishes/new")]
    public IActionResult DishForm()
    {
        List<Chef> CurrentChefs = new List<Chef>(); 
        List<Chef> EveryChef = _context.Chefs.ToList();
        ViewBag.SelectingChefs = EveryChef;
        return View("DishForm");
    }


    [HttpPost("dish/submission")]
    public IActionResult DishSubmission(Dish dish)
    {
        if(ModelState.IsValid)
        {
            dish.UpdatedAt = DateTime.Now;
            _context.Dishes.Add(dish);
            _context.SaveChanges();
            List<Dish> AllDishes = _context.Dishes.ToList();
            return RedirectToAction("DishIndex", AllDishes);
        }
        return View("DishForm");
    }
}


