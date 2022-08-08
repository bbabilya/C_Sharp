using Microsoft.AspNetCore.Mvc;
using Survey;
namespace DojoSurveyModel.Controllers; //defining namespace

public class SurveyController : Controller //inheritance from controller
{
    static SurveyModel NewEntry; 
    //declaring surveymodel as a global instance to access in our post and get results methods.

    //public string[] locations = new string[]
    // { 
    //     "locations for foreach"
    // }

    [HttpGet] // request type
    [Route("")] // associated route string, excluding lead /
    public ViewResult Form()
    {
        return View("Form");
    }

    [HttpGet] // request type
    [Route("results")] // associated route string, excluding lead /
    public IActionResult Results()
    {
        return View(NewEntry);
    }

[HttpPost("submission")]
public IActionResult SurveySubmission(SurveyModel entry)
// calling the surveymodel as well as an independent variable for instanced information
    {
        if(ModelState.IsValid)
        {
            NewEntry = entry;
        return RedirectToAction("Results");
        // returning the view of the page we want information to display on, as well as the independent variable for that instance of information.
        }
        else
        {
            return Form();
        }
    }
}