using Microsoft.AspNetCore.Mvc;
namespace Portfolio1.Controllers; //defining namespace

public class HelloController : Controller //inheritance from controller
{
    [HttpGet] // request type
    [Route("")] // associated route string, excluding lead /
    public ViewResult Index() //public display of a string using Index functionality
    {
        return View();
    }

    [HttpGet("projects")]
    public ViewResult About()
    {
        return View();
    }

    [HttpGet("contact")]
    public ViewResult Contact()
    {
        return View();
    }
}
