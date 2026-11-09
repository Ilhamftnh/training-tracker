using System.ComponentModel.DataAnnotations;

namespace TrainingTracker.Models;

public class TrainingRecord
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string EmployeeName { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string CourseTitle { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Display(Name = "Completed On")]
    public DateTime CompletedOn { get; set; }

    [Range(0, 100)]
    public int Score { get; set; }
}
