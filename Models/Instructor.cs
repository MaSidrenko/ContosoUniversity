using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity;

public class Instructor
{
    public int ID { get; set; }
    [Required]
    [Display(Name = "Last Name")]
    [StringLength(24, MinimumLength = 5)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z]*$",
        ErrorMessage = "Last name must start with a capital letter and contain only letters.")]
    public string LastName { get; set; }
    [Required]
    [Display(Name = "First Name")]
    [StringLength(24, MinimumLength = 5)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z]*$",
        ErrorMessage = "First name must start with a capital letter and contain only letters.")]
    public string FirstName { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Hire Date")]
    public DateTime HireDate { get; set; }

    // Navigation properties:
    public ICollection<CourseAssignment> CourseAssignments { get; set; }
    public OfficeAssignment OfficeAssignment { get; set; }
}
