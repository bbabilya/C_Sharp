using Microsoft.AspNetCore.Mvc;
using Survey;
namespace DojoSurveyModel.Controllers; //defining namespace

public class SurveyController : Controller //inheritance from controller
{
    [HttpGet] // request type
    [Route("")] // associated route string, excluding lead /
    public ViewResult Form()
    {
        return View("Form");
    }

[HttpPost("submission")]
public IActionResult SurveySubmission(SurveyModel entry)
// calling the surveymodel as well as an independent variable for instanced information
    {
        if(ModelState.IsValid)
        {
        return View("Results", entry);
        // returning the view of the page we want information to display on, as well as the independent variable for that instance of information.
        }
        else
        {
            return Form();
        }
    }
}