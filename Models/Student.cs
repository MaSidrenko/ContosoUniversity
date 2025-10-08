using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity;

public class Student
{
    public int ID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    
    public DateTime EnrollmentDate { get; set; } //Дата поступления
    public string FullName { get => $"{LastName} {FirstName}"; }
    // Navigation Propteties:
    public ICollection<Enrollment> Enrollments { get; set; }

}
