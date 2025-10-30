using GroupProject.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class Enrollment
    {
  

    [Key]
    public int EnrollmentID { get; set; }
    public Student Student { get; set; }
    public Course Course { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public EnrollmentStatus Status { get; set; }
    public string Grade { get; set; }


     // Is Primary key From Class Trainar and ForeignKey in Class Enrollment....
    [ForeignKey(nameof(student))]
    public Student student { get; set; }
    public int StudentID { get; set; }
    public ICollection<Student> students { get; set; } = new HashSet<Student>();


     // Is Primary key From Class Course and ForeignKey in Class Enrollment....
    [ForeignKey(nameof(course))]
    public Course course { get; set; }
    public int CourseID { get; set; }
    public ICollection<Course> courses { get; set; } = new HashSet<Course>();


     //Function
    public List<Payment> Payments { get; set; } = new List<Payment>();

    public decimal TotalPaid => Payments.Sum(p => p.AmountPaid);
    public decimal RemainingBalance => Course.Fee - TotalPaid;

    }
}

