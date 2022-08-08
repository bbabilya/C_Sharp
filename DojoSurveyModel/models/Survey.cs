using System.ComponentModel.DataAnnotations;
namespace Survey;
public class SurveyModel
{
    [Required]
    [MinLength(3)]
    public string NameField { get; set; }

    [Required]
    public string DojoField { get; set; }

    [Required]
    public string LanguageField { get; set; }

    [MinLength(20)]
    public string? CommentField { get; set; }
}