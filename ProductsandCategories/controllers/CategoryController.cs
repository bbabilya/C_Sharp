// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsandCategories.Models;
using Microsoft.EntityFrameworkCore;
namespace ProductsandCategories.Controllers;

public class CategoryController : Controller
{
    private MyContext _context;
    public CategoryController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("categories")]
    public IActionResult CategoryIndex()
    {
        List<Category> CreatedCategories = new List<Category>(); 
        List<Category> AllCategories = _context.Categories.ToList();
        ViewBag.Categories = AllCategories;

        return View("CategoryIndex");
    }

    [HttpGet("/categories/{id}")]
    public IActionResult CategoryDetails(int id)
    {
        Category? category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        ViewBag.SingleCategory = category;
        ViewBag.AssociatedProducts = _context.Products
            //all of its current categories
            //pulling all products
            .Include(c => c.ListedCategories)
            //all of the data in the categories list(?)
            .ThenInclude(c => c.Category)
            //Category specifically?
            .Where(p => p.ListedCategories
            //Where the category is not equal to set category?
            .Any(c => c.CategoryId == id))
            .ToList();

        ViewBag.ListedProducts = _context.Products
            //dropdown menu categories
            //pulling all products
            .Include(c => c.ListedCategories)
            //all of the data in the categories list(?)
            .ThenInclude(c => c.Category)
            //Category specifically?
            .Where(p => !p.ListedCategories
            //Where the category is not equal to set category?
            .Any(c => c.CategoryId == id))
            .ToList();
        return View("CategoryDetails");
    }

    [HttpPost("categories/submission")]
    public IActionResult CategorySubmission(Category category)
    {
        if(ModelState.IsValid)
        {
            category.UpdatedAt = DateTime.Now;
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryIndex");
        }
        return View("CategoryIndex");
    }


    [HttpPost("categories/{id}/associations/submission")]
    public IActionResult CatAssociationSubmission(Association association, int id)
    {
        association.CategoryId = id;
        _context.Association.Add(association);
        _context.SaveChanges();
        return RedirectToAction("CategoryIndex");
    }
}