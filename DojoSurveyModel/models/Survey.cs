using System.ComponentModel.DataAnnotations;
namespace Survey;
public class SurveyModel
{
    [Required]
    [MinLength(3)]
    public string NameField { get; set; } = null!; 

    [Required]
    public string DojoField { get; set; } = null!;

    [Required]
    public string LanguageField { get; set; } = null!;

    [MinLength(20)]
    public string CommentField { get; set; } = null!;
}