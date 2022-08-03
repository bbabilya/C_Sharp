using Microsoft.AspNetCore.Mvc;
namespace Portfolio1.Controllers; //defining namespace

public class HelloController : Controller //inheritance from controller
{
    [HttpGet] // request type
    [Route("")] // associated route string, excluding lead /
    public string Index() //public display of a string using Index functionality
    {
        return "Hello from HelloController!";
    }

    [HttpGet("projects")]
    public string About()
    {
        return "These are my projects!";
    }

    [HttpGet("contact")]
    public string FormSubmission(string formInput)
    {
        return "This is my contact info!";
    }
}
