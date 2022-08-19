using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
namespace WeddingPlanner.Controllers;


public class LoginController : Controller
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
    public LoginController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        HttpContext.Session.Clear();
        return View("Index");
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginUser userSubmission)
    {
    if(ModelState.IsValid)
    {
        var userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.EmailLogin);
        if(userInDb == null)
        {
            ModelState.AddModelError("EmailLogin", "Invalid Email/Password");
            return Index();
        }
        
        var hasher = new PasswordHasher<LoginUser>();
        var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.PasswordLogin);

        if(result == 0)
        {
            ModelState.AddModelError("EmailLogin", "Invalid Email/Password.");
            return Index();
        }
        else
        {

            HttpContext.Session.SetInt32("session", userInDb.UserId);
            return RedirectToAction("Dashboard", "Wedding");
        }
    }
        return RedirectToAction("Dashboard", "Wedding");
    }

    [HttpPost("submission")]
    public IActionResult UserSubmit(User user)
    {
        if(ModelState.IsValid)
        {
            user.UpdatedAt = DateTime.Now;
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            user.Password = Hasher.HashPassword(user, user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("session", user.UserId);
            Console.WriteLine(id);
            return RedirectToAction("Dashboard", "Wedding");
        }
        return Index();
    }
}

