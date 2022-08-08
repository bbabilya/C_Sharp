using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace RandomPasscode.Controllers;

public class NumberController : Controller 
{
    [HttpGet]
    [Route("")] 
    public ViewResult Number()
    {   
        int? count = HttpContext.Session.GetInt32("NumGen");
        if (count == null)
        {
            count = -1;
        }
        count++;



        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXZ0123456789";
        string passcode = new string(Enumerable.Repeat(chars, 14).Select(s => s[random.Next(s.Length)]).ToArray());

        HttpContext.Session.SetInt32("NumGen", (int)count);
        if(count == 0)
        {
            HttpContext.Session.SetString("PassWord", "");
        }
        else
        {
        HttpContext.Session.SetString("PassWord", passcode);
        }
        return View("Number");
    }
}