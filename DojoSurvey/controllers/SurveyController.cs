using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers; //defining namespace

public class SurveyController : Controller //inheritance from controller
{
    [HttpGet] // request type
    [Route("")] // associated route string, excluding lead /
    public ViewResult Form()
    {
        return View();
    }

[HttpPost]
[Route("submission")]
public IActionResult FormSubmission(string NameField, string DojoField, string LanguageField, string CommentField)
    {
        ViewBag.Name = NameField;
        ViewBag.Dojo = DojoField;
        ViewBag.Language = LanguageField;
        ViewBag.Comment = CommentField;
        return View("Results");
    }
}