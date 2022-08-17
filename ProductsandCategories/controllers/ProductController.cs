// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsandCategories.Models;
namespace ProductsandCategories.Controllers;
    
public class ProductController : Controller
{
    private MyContext _context;
    public ProductController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    [HttpGet("products")]
    public IActionResult ProductIndex()
    {

        List<Product> CreatedProducts = new List<Product>(); 
        List<Product> AllProducts = _context.Products.ToList();
        ViewBag.Products = AllProducts;

        return View("ProductIndex");
    }

    [HttpGet("/products/{id}")]
    public IActionResult Details(int id)
    {
        Product? product = _context.Products.FirstOrDefault(p => p.ProductId == id);
        ViewBag.SingleProduct = product;
        ViewBag.AssociatedCategories = _context.Categories
            //all of its current categories
            //pulling all products
            .Include(c => c.ListedProducts)
            //all of the data in the categories list(?)
            .ThenInclude(c => c.Product)
            //Category specifically?
            .Where(p => p.ListedProducts
            //Where the category is not equal to set category?
            .Any(c => c.ProductId == id))
            .ToList();

        ViewBag.ListedCategories = _context.Categories
            //dropdown menu categories
            //pulling all products
            .Include(c => c.ListedProducts)
            //all of the data in the categories list(?)
            .ThenInclude(c => c.Product)
            //Category specifically?
            .Where(p => !p.ListedProducts
            //Where the category is not equal to set category?
            .Any(c => c.ProductId == id))
            .ToList();
        return View("ProductDetails");
    }

    [HttpPost("products/submission")]
    public IActionResult ProductSubmission(Product product)
    {
        if(ModelState.IsValid)
        {
            product.UpdatedAt = DateTime.Now;
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("ProductIndex");
        }
        return View("ProductIndex");
    }


    [HttpPost("products/{id}/associations/submission")]
    public IActionResult ProdAssociationSubmission(Association association, int id)
    {
        association.ProductId = id;
        _context.Association.Add(association);
        _context.SaveChanges();
        return RedirectToAction("ProductIndex");
    }
}