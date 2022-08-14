// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
namespace CRUDelicious.Controllers;
    
public class HomeController : Controller
{
    private MyContext _context;

    // here we can "inject" our context service into the constructor
    public HomeController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.ToList();

        return View("Home", AllDishes);
    }

    [HttpGet("/new")]
    public IActionResult DishForm()
    {
        return View("Form");
    }

    [HttpGet("/dish/{id}")]
    public IActionResult Details(int id)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
        return View("Details", dish);
    }

    [HttpGet("/dish/{id}/edit")]
    public IActionResult DishUpdate(int id)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
        // if(ModelState.IsValid)
        // {
        //     Console.WriteLine(dish);
        //     dish.Name = editedDish.Name;
        //     dish.Chef = editedDish.Chef;
        //     dish.Tastiness = editedDish.Tastiness;
        //     dish.Calories = editedDish.Calories;
        //     dish.Description = editedDish.Description;
        //     dish.UpdatedAt = DateTime.Now;
        //     _context.SaveChanges();
        //     return RedirectToAction("DishDetails", editedDish);
        // }
        return View("UpdateForm", dish);
    }

    
    [HttpPost("/dish/{id}/update")]
    public IActionResult DishSubmitUpdate(int id, Dish editedDish)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
        if(ModelState.IsValid)
        {
            dish.Name = editedDish.Name;
            dish.Chef = editedDish.Chef;
            dish.Tastiness = editedDish.Tastiness;
            dish.Calories = editedDish.Calories;
            dish.Description = editedDish.Description;
            dish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            List<Dish> AllDishes = _context.Dishes.ToList();
            return RedirectToAction("Index", AllDishes);
        }
        return DishUpdate(id);
    }


    [HttpPost("submission")]
    public IActionResult DishSubmission(Dish dish)
    {
        if(ModelState.IsValid)
        {
            dish.UpdatedAt = DateTime.Now;
            _context.Dishes.Add(dish);
            _context.SaveChanges();
            List<Dish> AllDishes = _context.Dishes.ToList();
            return RedirectToAction("Index", AllDishes);
        }
        return View("Form");
    }

    [HttpGet("/{id}/delete")]
    public IActionResult DeleteDish(int id)
    {
    Dish? SingleDish = _context.Dishes.SingleOrDefault(d => d.DishId == id);
    _context.Dishes.Remove(SingleDish);
    _context.SaveChanges();
    return RedirectToAction("Index");
    }
}


