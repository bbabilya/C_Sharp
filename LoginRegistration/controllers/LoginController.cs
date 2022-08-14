using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Models;
namespace LoginRegistration.Controllers;


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
        return View("Index");
    }

    [HttpGet("/login")]
    public IActionResult LoginPage()
    {
        return View("Login");
    }

    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }


    [HttpPost("/login")]
    public IActionResult Login(LoginUser userSubmission)
    {
    if(ModelState.IsValid)
    {
        var userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
        if(userInDb == null)
        {
            ModelState.AddModelError("Email", "Invalid Email/Password");
            return LoginPage();
        }
        
        var hasher = new PasswordHasher<LoginUser>();
        var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);

        if(result == 0)
        {
            ModelState.AddModelError("Email", "Invalid Email/Password.");
            return LoginPage();
        }
        else
        {

            HttpContext.Session.SetInt32("session", userInDb.UserId);
            return RedirectToAction("Success");
        }

    }
    return LoginPage();
    }

    [HttpGet("success")]
    public IActionResult Success()
    {
        if(id == null)
        {
            return Index();
        }
        return View("Success");
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
            return RedirectToAction("Success");
        }
        return View("Index");
    }
}

